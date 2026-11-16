using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SistRent.Application.Services
{

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IEmailService _emailService;
        private readonly IPasswordResetTokenRepository _passwordResetTokenRepository;
        private readonly IConfiguration _configuration;
        private readonly IRefreshTokenService _refreshTokenService;

        public AuthService(IUserRepository userRepository,IPasswordHasher<User> passwordHasher,IJwtTokenGenerator jwtTokenGenerator,IEmailService emailService,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
            _emailService = emailService;
            _configuration = configuration;
        }

        // LOGIN
        public async Task<LoginResponseDto> LoginAsync(LoginUserDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user is null)
                throw new UnauthorizedAccessException("Correo o contraseña incorrectos.");

            if (!user.Status)
                throw new UnauthorizedAccessException("La cuenta está desactivada.");

            var result = _passwordHasher.VerifyHashedPassword(user,user.PasswordHash,request.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("Correo o contraseña incorrectos.");

            // Actualizar hash si el algoritmo lo requiere
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                user.PasswordHash = _passwordHasher.HashPassword(user,request.Password);

                await _userRepository.UpdateAsync(user);
            }

            var jwtUser = new JwtUserDto
            {
                IdUser = user.IdUser,
                Email = user.Email,
                FullName = user.FullName,
                Roles = new List<string>
                {
                    user.Role.Name
                }
            };

            var token = _jwtTokenGenerator.GenerateToken(jwtUser);

            return new LoginResponseDto(
                Token: token.AccessToken,
                IdUser: user.IdUser,
                FullName: user.FullName,
                Email: user.Email,
                Role: user.Role.Name,
                MustChangePassword: user.MustChangePassword
            );
        }

        // CHANGE PASSWORD
        public async Task ChangePasswordAsync(int userId,ChangePasswordDto request)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)
                throw new KeyNotFoundException("Usuario no encontrado.");

            var result = _passwordHasher.VerifyHashedPassword(user,user.PasswordHash,request.CurrentPassword);

            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException("La contraseña actual es incorrecta.");

            if (request.CurrentPassword == request.NewPassword)
                throw new ArgumentException("La nueva contraseña debe ser diferente.");

            user.PasswordHash = _passwordHasher.HashPassword(user,request.NewPassword);

            user.MustChangePassword = false;

            await _userRepository.UpdateAsync(user);
        }

        // RESET PASSWORD
        public async Task ResetPasswordAsync(int userId,ResetPasswordDto request)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null)throw new KeyNotFoundException("Usuario no encontrado.");

            user.PasswordHash = _passwordHasher.HashPassword(user,request.NewPassword);

            // El usuario deberá cambiarla al iniciar sesión
            user.MustChangePassword = true;

            await _userRepository.UpdateAsync(user);
        }



        public async Task ForgotPasswordAsync(ForgotPasswordDto request)
        {
            // 1. Buscar usuario por correo
            var user = await _userRepository.GetByEmailAsync(request.Email);

            // No revelar si el correo existe o no
            if (user == null || !user.Status)
                return;

            // 2. Generar token seguro
            var tokenBytes = RandomNumberGenerator.GetBytes(64);

            var token = WebEncoders.Base64UrlEncode(tokenBytes);

            // 3. Generar hash del token
            var tokenHash = Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

            // 4. Crear entidad de recuperación
            var resetToken = new PasswordResetToken
            {
                IdUser = user.IdUser,
                TokenHash = tokenHash,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddMinutes(15),
                UsedAt = null
            };

            // 5. Guardar token en base de datos
            await _passwordResetTokenRepository.AddAsync(resetToken);

            // 6. Construir enlace de recuperación
            var frontendUrl = _configuration["AppSettings:FrontendUrl"];

            var resetLink =
                $"{frontendUrl}/reset-password" +
                $"?email={Uri.EscapeDataString(user.Email)}" +
                $"&token={Uri.EscapeDataString(token)}";

            // 7. Enviar correo
            await _emailService.SendPasswordResetAsync(
                user.Email,
                resetLink
            );
        }

        public async Task ResetPasswordWithTokenAsync(ResetPasswordWithTokenDto request)
        {
            // 1. Validar los datos recibidos
            if (string.IsNullOrWhiteSpace(request.Email) ||string.IsNullOrWhiteSpace(request.Token) ||string.IsNullOrWhiteSpace(request.NewPassword))
            {
                throw new ArgumentException("Los datos de recuperación son obligatorios.");
            }

            // 2. Verificar que las contraseñas coincidan
            if (request.NewPassword != request.ConfirmPassword)
            {
                throw new ArgumentException("Las contraseñas no coinciden.");
            }

            // 3. Generar el hash del token recibido
            var tokenHash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(request.Token)));

            // 4. Buscar el token válido por correo y hash
            var resetToken =await _passwordResetTokenRepository.GetValidTokenAsync(request.Email,tokenHash);

            // 5. Verificar que el token exista
            if (resetToken is null)
            {
                throw new UnauthorizedAccessException(
                    "El token es inválido o ha expirado.");
            }

            // 6. Verificar que el token no haya sido utilizado
            if (resetToken.UsedAt.HasValue)
            {
                throw new UnauthorizedAccessException(
                    "El token ya fue utilizado.");
            }

            // 7. Verificar la expiración
            if (resetToken.ExpiresAt <= DateTimeOffset.UtcNow)
            {
                throw new UnauthorizedAccessException(
                    "El token ha expirado.");
            }

            // 8. Obtener el usuario
            var user = await _userRepository.GetByIdAsync(
                resetToken.IdUser);

            if (user is null || !user.Status)
            {
                throw new UnauthorizedAccessException(
                    "No se puede restablecer la contraseña.");
            }

            // 9. Generar el nuevo hash de contraseña
            user.PasswordHash = _passwordHasher.HashPassword(user,request.NewPassword);

            // 10. Actualizar el usuario
            user.MustChangePassword = false;

            await _userRepository.UpdateAsync(user);

            // 11. Marcar el token como utilizado
            resetToken.UsedAt = DateTimeOffset.UtcNow;

            await _passwordResetTokenRepository.UpdateAsync(resetToken);

            // 12. Revocar las sesiones anteriores del usuario
            await _refreshTokenService.RevokeAllAsync(user.IdUser);
        }
    }

}

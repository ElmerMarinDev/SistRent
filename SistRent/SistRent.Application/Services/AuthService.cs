using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(IUserRepository userRepository,IPasswordHasher<User> passwordHasher,IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDto> LoginAsync(
            LoginUserDto request)
        {
            // 1. Buscar usuario por correo
            var user = await _userRepository.GetByEmailAsync(
                request.Email);

            if (user is null)
                throw new UnauthorizedAccessException(
                    "Credenciales incorrectas.");

            // 2. Verificar contraseña
            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                request.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new UnauthorizedAccessException(
                    "Credenciales incorrectas.");

            // 3. Verificar si la cuenta está activa
            // Ajustar según el tipo de dato de User.Status.
            if (!user.Status)
                throw new UnauthorizedAccessException(
                    "La cuenta está desactivada.");

            // 4. Generar token JWT
            var token = _jwtTokenGenerator.GenerateToken(user);

            // 5. Devolver respuesta
            return new LoginResponseDto(
                Token: token,
                IdUser: user.IdUser,
                FullName: user.FullName,
                Email: user.Email,
                MustChangePassword: user.MustChangePassword
            );
        }

        public Task ChangePasswordAsync(
            int userId,
            ChangePasswordDto request)
        {
            throw new NotImplementedException();
        }

        public Task ResetPasswordAsync(
            int userId,
            ResetPasswordDto request)
        {
            throw new NotImplementedException();
        }

    }
}

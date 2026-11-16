using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Infrastructure.DataBase.Configurations;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistRent.Infrastructure.Security
{
    public class JwtTokenGenerator:IJwtTokenGenerator
    {
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(
            IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public LoginTokenDto GenerateToken(JwtUserDto user)
        {
            var expiresAt = DateTimeOffset.UtcNow
                .AddMinutes(_jwtSettings.ExpirationMinutes);

            // 1. Crear los Claims
            var claims = new List<Claim>
            {
                new Claim(
                    ClaimTypes.NameIdentifier,
                    user.IdUser.ToString()
                ),

                new Claim(
                    ClaimTypes.Email,
                    user.Email
                ),

                new Claim(
                    ClaimTypes.Name,
                    user.FullName
                ),

                new Claim(
                    JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString()
                )
            };

            // 2. Agregar los roles del usuario
            foreach (var role in user.Roles)
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role)
                );
            }

            // 3. Crear la clave de seguridad
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.SecretKey)
            );

            // 4. Crear las credenciales
            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            // 5. Crear el JWT
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: expiresAt.UtcDateTime,
                signingCredentials: credentials
            );

            // 6. Devolver el token y su expiración
            return new LoginTokenDto
            {
                AccessToken = new JwtSecurityTokenHandler()
                    .WriteToken(token),

                ExpiresAt = expiresAt
            };
        }
    }
}

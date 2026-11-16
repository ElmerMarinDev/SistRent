using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SistRent.Application.Services
{
   public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RefreshTokenService(
            IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<RefreshTokenResponseDto> CreateAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user is null || !user.Status)
                throw new UnauthorizedAccessException(
                    "Usuario no válido.");

            var rawToken = GenerateRefreshToken();
            var tokenHash = HashToken(rawToken);

            var now = DateTimeOffset.UtcNow;
            var expiresAt = now.AddDays(7);

            var refreshToken = new RefreshToken
            {
                IdUser = user.IdUser,
                TokenHash = tokenHash,
                CreatedAt = now,
                ExpiresAt = expiresAt
            };

            await _refreshTokenRepository.AddAsync(refreshToken);
            await _refreshTokenRepository.SaveChangesAsync();

            return new RefreshTokenResponseDto
            {
                RefreshToken = rawToken,
                RefreshTokenExpiresAt = expiresAt
            };
        }

        public async Task<RefreshTokenResponseDto> RefreshAsync(
            string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                throw new UnauthorizedAccessException(
                    "Token no válido.");

            var tokenHash = HashToken(refreshToken);

            var storedToken =
                await _refreshTokenRepository.GetByHashAsync(tokenHash);

            var now = DateTimeOffset.UtcNow;

            if (storedToken is null ||
                storedToken.RevokedAt is not null ||
                storedToken.ExpiresAt <= now)
            {
                throw new UnauthorizedAccessException(
                    "El refresh token no es válido o ha expirado.");
            }

            var user = await _userRepository.GetByIdAsync(
                storedToken.IdUser);

            if (user is null || !user.Status)
                throw new UnauthorizedAccessException(
                    "Usuario no válido.");

            // Generar nuevo refresh token.
            var newRawToken = GenerateRefreshToken();
            var newTokenHash = HashToken(newRawToken);
            var newExpiresAt = now.AddDays(7);

            // Invalidar el refresh token anterior.
            storedToken.RevokedAt = now;
            storedToken.ReplacedByTokenHash = newTokenHash;

            var newRefreshToken = new RefreshToken
            {
                IdUser = user.IdUser,
                TokenHash = newTokenHash,
                CreatedAt = now,
                ExpiresAt = newExpiresAt
            };

            await _refreshTokenRepository.AddAsync(newRefreshToken);
            await _refreshTokenRepository.UpdateAsync(storedToken);
            await _refreshTokenRepository.SaveChangesAsync();

            // Convertir User en JwtUserDto.
            var jwtUser = new JwtUserDto
            {
                IdUser = user.IdUser,
                Email = user.Email,
                FullName = user.FullName,
                Roles = [user.Role.Name]
            };

            // Generar nuevo JWT.
            var loginToken = _jwtTokenGenerator.GenerateToken(jwtUser);

            return new RefreshTokenResponseDto
            {
                AccessToken = loginToken.AccessToken,
                AccessTokenExpiresAt = loginToken.ExpiresAt,
                RefreshToken = newRawToken,
                RefreshTokenExpiresAt = newExpiresAt
            };
        }

        public async Task RevokeAsync(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
                return;

            var tokenHash = HashToken(refreshToken);

            var storedToken =
                await _refreshTokenRepository.GetByHashAsync(tokenHash);

            if (storedToken is null ||
                storedToken.RevokedAt is not null)
                return;

            storedToken.RevokedAt = DateTimeOffset.UtcNow;

            await _refreshTokenRepository.UpdateAsync(storedToken);
            await _refreshTokenRepository.SaveChangesAsync();
        }

        public async Task RevokeAllAsync(int userId)
        {
            var tokens = await _refreshTokenRepository
                .GetActiveByUserIdAsync(userId);

            var now = DateTimeOffset.UtcNow;

            foreach (var token in tokens)
            {
                token.RevokedAt = now;
            }

            await _refreshTokenRepository.UpdateRangeAsync(tokens);
            await _refreshTokenRepository.SaveChangesAsync();
        }

        private static string GenerateRefreshToken()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);

            return Convert.ToBase64String(bytes)
                .Replace("+", "-")
                .Replace("/", "_")
                .TrimEnd('=');
        }

        private static string HashToken(string token)
        {
            var bytes = SHA256.HashData(
                System.Text.Encoding.UTF8.GetBytes(token));

            return Convert.ToHexString(bytes);
        }
    }
}

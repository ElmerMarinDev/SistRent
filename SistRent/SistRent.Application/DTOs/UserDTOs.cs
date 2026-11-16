using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record UserResponseDto(
        int IdUser,
        string Role,
        string FullName,
        string Email,
        string Dni,
        bool Status,
        bool MustChangePassword,
        string? ImageSource,
        DateTimeOffset CreatedAt
    );

    public record LoginResponseDto(
        string Token,
        int IdUser,
        string FullName,
        string Email,
        string Role,
        bool MustChangePassword
);


    public record LoginUserDto(
        string Email,
        string Password
    );

    public record ChangePasswordDto(
        int UserId,
        string CurrentPassword,
        string NewPassword
);
    public record UserCreateDto(
        int IdRole,
        string FullName,
        string Email,
        string Dni,
        string Phone,
        string Password,
        bool Status,
        string? ImageSource
    );

    public record UserUpdateDto(
        int UserId,
        int IdRole,
        string FullName,
        string Email,
        bool Status,
        string Phone,
        string? ImageSource,
        bool MustChangePassword,
        Stream? ImageStream,
        string? ImageFileName
    );

    public record ResetPasswordDto(
        string NewPassword
    );

    public record ForgotPasswordDto(
        string Email
    );

    public record ResetPasswordWithTokenDto(
        string Email,
        string Token,
        string NewPassword,
        string ConfirmPassword
    );

    public record RefreshTokenRequestDto
    {
        public string RefreshToken { get; init; } = string.Empty;
    }

    public record RefreshTokenResponseDto
    {
        public string AccessToken { get; init; } = string.Empty;

        public DateTimeOffset AccessTokenExpiresAt { get; init; }

        public string RefreshToken { get; init; } = string.Empty;

        public DateTimeOffset RefreshTokenExpiresAt { get; init; }
    }


    public record LoginTokenDto
    {
        public string AccessToken { get; init; } = string.Empty;

        public DateTimeOffset ExpiresAt { get; init; }
    }

    public record JwtUserDto
    {
        public int IdUser { get; init; }

        public string Email { get; init; } = string.Empty;

        public string FullName { get; init; } = string.Empty;

        public IList<string> Roles { get; init; } = [];
    }






}

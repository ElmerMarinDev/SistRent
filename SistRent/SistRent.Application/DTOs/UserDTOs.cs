using System;
using System.Collections.Generic;
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

    public record LoginUserDto(
        string Email,
        string Password
    );

    public record ChangePasswordDto(
        int UserId,
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

}

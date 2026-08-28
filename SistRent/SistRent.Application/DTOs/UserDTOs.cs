using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public record UserCreateDto(
    int IdRole,
    string FullName,
    string Email,
    string Password,
    bool Status,
    string? ImageSource
);

    public record UserUpdateDto(
    int IdRole,
    string FullName,
    string Email,
    bool Status,
    string? ImageSource
);

    public record UserResponseDto(
    int IdUser,
    int IdRole,
    string FullName,
    string Email,
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
    string CurrentPassword,
    string NewPassword
);

    public record ResetPasswordDto(
    string NewPassword
);

}

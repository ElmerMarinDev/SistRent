using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record RoleCreateDto(
        string Name,
        string? Description
    );

    public record RoleUpdateDto(
        string Name,
        string? Description
    );

    public record RoleResponseDto(
        int IdRole,
        string Name,
        string? Description,
        DateTimeOffset RegistrationDate
    );
}

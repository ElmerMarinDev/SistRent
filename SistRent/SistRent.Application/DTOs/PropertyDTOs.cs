using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public record PropertyCreateDto(
        string Name,
        string Address,
        string? Description,
        bool Status
    );
    public record PropertyUpdateDto(
        string Name,
        string Address,
        string? Description,
        bool Status
    );
    public record PropertyResponseDto(
        int IdProperty,
        string Name,
        string Address,
        string? Description,
        bool Status,
        DateTimeOffset RegistrationDate
    );
}



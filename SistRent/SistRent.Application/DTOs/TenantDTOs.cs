using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record TenantCreateDto(
        int IdUser,
        string Dni,
        string? Phone,
        string? EmergencyContact,
        bool Status
    );
    public record TenantUpdateDto(
        string Dni,
        string? Phone,
        string? EmergencyContact,
        bool Status
    );

    public record TenantResponseDto(
        int IdTenant,
        int IdUser,
        string Dni,
        string? Phone,
        string? EmergencyContact,
        DateTimeOffset RegistrationDate,
        bool Status
    );

    public record TenantDetailDto(
        int IdTenant,
        int IdUser,
        string FullName,
        string Email,
        string Dni,
        string? Phone,
        string? EmergencyContact,
        DateTimeOffset RegistrationDate,
        bool Status,
        IReadOnlyCollection<ContractResponseDto> Contracts
    );
}


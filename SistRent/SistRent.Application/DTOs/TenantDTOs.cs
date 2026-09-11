using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record TenantCreateDto(
        string Dni,
        string? Phone,
        string?Email,
        string?Fullname,
        string? EmergencyContact,
        bool Status
    );
    public record TenantUpdateDto(
        int TenantId,
        string fullname,
        string Email,
        string Dni,
        string? Phone,
        string Password,
        string? EmergencyContact,
        Stream?ImageStream,
        string?ImageFileName,
        bool Status
    );

    public record TenantResponseDto(
        int IdTenant,
        string fullname,
        string Email,
        string Password,
        string? ImageSource,
        string Dni,
        string? Phone,
        string? EmergencyContact
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


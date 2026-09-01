using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record ContractCreateDto(
        int IdTenant,
        int IdRoom,
        int IdContractStatus,
        DateTime StartDate,
        DateTime EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        string? Notes
        );

    public record ContractUpdateDto(
        int IdRoom,
        int IdContractStatus,
        DateTime StartDate,
        DateTime EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        string? Notes
        );

    public record ContractResponseDto(
        int IdContract,
        int IdTenant,
        int IdRoom,
        int IdContractStatus,
        DateTime StartDate,
        DateTime EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        DateTimeOffset RegistrationDate,
        string? Notes
        );

    public record ContractDetailDto(
        int IdContract,
        int IdTenant,
        string TenantName,
        int IdRoom,
        string RoomNumber,
        int IdContractStatus,
        string ContractStatus,
        DateTime StartDate,
        DateTime EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        DateTimeOffset RegistrationDate,
        string? Notes,
        IReadOnlyCollection<PaymentResponseDto> Payments
        );

}

using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record ContractCreateDto(
        int IdUser,
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
        string FullName,
        string RoomNumber,
        string ContractStatus,
        DateTime StartDate,
        DateTime EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        DateTimeOffset RegistrationDate
        );

    public record ContractDetailDto(
        int IdContract,
        string FullName,
        string RoomNumber,
        string ContractStatus,
        DateTime StartDate,
        DateTime EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        DateTimeOffset RegistrationDate,
        IReadOnlyCollection<PaymentResponseDto> Payments
        );

}

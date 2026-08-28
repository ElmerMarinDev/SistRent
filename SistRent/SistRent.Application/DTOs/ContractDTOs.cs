using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record ReadContractDto(
        int ContractId,
        int RoomId,
        int TenantId,
        DateTime StartDate,
        DateTime? EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        string Status,
        DateTime RegistrationDate
    );

    public record CreateContractDto(
        int RoomId,
        int TenantId,
        DateTime StartDate,
        DateTime? EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit
    );

    public record UpdateContractDto(
        int RoomId,
        int TenantId,
        DateTime StartDate,
        DateTime? EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        string Status
    );

    public record ContractDetailDto(
        int IdContrat,
        int IdRoom,
        int IdTenant,
        DateTimeOffset StartDate,
        DateTimeOffset EndDate,
        decimal MonthlyAmount,
        decimal SecurityDeposit,
        bool Status,
        DateTimeOffset RegistrationDate,
        IEnumerable<PaymentReadDto> Payments
    );
    public record PaymentReadDto(
        int PaymentId,
        int ContractId,
        decimal Amount,
        string PaymentMethod,
        DateTime PaymentDate,
        string Status,
        DateTime RegistrationDate
    );

}

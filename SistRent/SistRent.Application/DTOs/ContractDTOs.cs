using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

    public record ContractReadDTO(
        int ContractId, 
        RoomReadDTO Room, 
        TenantReadDTO Tenant,
        DateTime StartDate, 
        DateTime EndDate,
        decimal MonthyAmount, 
        decimal SecuryDeposit,
        string status, 
        DateTime RegistrationDate, 
        ICollection<ContractPaymentReadDTO> Payments
        );

    public record RoomReadDTO(
        int IdRoom,
        int IdProperty,
        int IdRoomType,
        decimal MonthyPrice,
        string Description,
        RoomTypeReadDTO RoomType
    );

    public record RoomTypeReadDTO(
        int IdRoomType,
        string Name,
        string Description
     );

    public record TenantReadDTO(
    int IdTenant,
    string FirstName,
    string LastName,
    string Dni,
    string Phone,
    string Email,
    bool status,
    DateTime RegistrationDate
 );

}

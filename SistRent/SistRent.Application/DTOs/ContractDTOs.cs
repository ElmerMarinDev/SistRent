using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public class ContractDTOs
    {
        public record contractDTO(int ContractId, string TenantName, string ContractDate);
        public record PaymentDTO(string Email, string Password);
        public record ChangePasswordUserDTO(int UserId, string NewPassword);
        public record CreateUserDTO(string FullName, string Email, string Role, string Password);
        public record UpdateUserDTO(int UserId, string FullName, string Email, string Role, bool ResetPassword);
    }
}

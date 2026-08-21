using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public class TenantDTOs
    {
        public record TenantDTO(int UserId, string FullName, string Email, string Role, bool ResetPassword);
        public record CreateTenantDTO(string FullName, string Email, string Role, string Password);
        public record UpdateTenantDTO(int UserId, string FullName, string Email, string Role, bool ResetPassword);

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class Tenant
    {
        public int TenantId { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        [Required]
        public required string Dni { get; set; }

        [Required]
        public required string Telefono { get; set; }

        [Required]
        public required string Email { get; set; }

        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow; 
        public bool Status { get; set; }
    }
}

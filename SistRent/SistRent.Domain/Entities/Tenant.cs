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
        public required string Phone { get; set; }

        [Required]
        public required string Email { get; set; }

        public string SourceImagen { get; set; } = string.Empty;

        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow; 
        public bool Status { get; set; }

        public virtual ICollection<Contract> Contract { get; set; } = new List<Contract>();
    }
}

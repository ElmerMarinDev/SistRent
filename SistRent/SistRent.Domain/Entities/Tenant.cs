using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Domain.Entities
{

    public class Tenant
    {
        public int IdTenant { get; set; }

        public int IdUser { get; set; }

        [Required]
        public string Dni { get; set; } = null!;

        public string? Phone { get; set; }

        public string? EmergencyContact { get; set; }

        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow;

        public bool Status { get; set; }

        public virtual User User { get; set; } = null!;

        public virtual ICollection<Contract> Contracts { get; set; }
            = new List<Contract>();
    }
}

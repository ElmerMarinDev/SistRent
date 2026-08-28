using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Domain.Entities
{

    public class User
    {
        public int IdUser { get; set; }

        public int IdRole { get; set; }

        [Required]
        public string FullName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        public bool Status { get; set; }

        public bool MustChangePassword { get; set; }

        public string? ImageSource { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }= DateTimeOffset.UtcNow;

        public virtual Role Role { get; set; } = null!;

        // Un User puede tener 0 o 1 Tenant
        public virtual Tenant? Tenant { get; set; }
    }
}

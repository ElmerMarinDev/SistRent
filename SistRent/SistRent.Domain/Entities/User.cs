using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public required string FullName { get;set; }

        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        public required string Role { get; set; }
        public bool Status { get; set; }

        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow;
    }
}

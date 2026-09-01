using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Domain.Entities
{

    public class Role
    {
        public int IdRole { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}

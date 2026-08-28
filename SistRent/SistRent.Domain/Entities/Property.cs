using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{

    public class Property
    {
        public int IdProperty { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        public string? Description { get; set; }

        public bool Status { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }= DateTimeOffset.UtcNow;

        public virtual ICollection<Room> Rooms { get; set; }
            = new List<Room>();
    }
}

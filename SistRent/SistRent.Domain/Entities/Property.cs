using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class Property
    {
        public int IdProperty { get; set; }


        public string? Name { get; set; }

        public string? Adress { get; set; }

        public bool Status { get; set; }
        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow;

        public virtual ICollection<Room> Room { get; set; } = new List<Room>();

    }
}

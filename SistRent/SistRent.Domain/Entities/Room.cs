using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class Room
    {
        public int IdRoom { get; set; }

        public string? Adress { get; set; }

        public string? RoomNumber { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MonthyPrice { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Contract> Contract { get; set; } = new List<Contract>();
    }
}

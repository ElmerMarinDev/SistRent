using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class Room
    {
        public int IdRoom { get; set; }

        public int IdProperty { get; set; }

        public int IdRoomType { get; set; }

        [Required]
        public string RoomNumber { get; set; } = null!;

        public string? Floor { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MonthlyPrice { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public string? Description { get; set; }

        public virtual Property Property { get; set; } = null!;

        public virtual RoomType RoomType { get; set; } = null!;

        public virtual ICollection<Contract> Contracts { get; set; }
            = new List<Contract>();
    }
}

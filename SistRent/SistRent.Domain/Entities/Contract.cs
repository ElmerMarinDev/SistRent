using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class Contract
    {
        public int IdContrat { get; set; }

        public int IdRoom { get; set; }

        public int IdTenant { get; set; }

        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        public decimal MonthyAmount { get; set; }


        [Column(TypeName = "decimal(10,2)")]
        public decimal SecurityDeposit { get; set; }

        public bool Status { get; set; }
        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow;

        public virtual Room Room { get; set; } = null!;
        public virtual Tenant Tenant { get; set; } = null!;

        public virtual ICollection<Payment> Payment { get; set; } = new List<Payment>();

    }
}

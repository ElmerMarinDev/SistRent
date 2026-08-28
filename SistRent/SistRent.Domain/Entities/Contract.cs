using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{

    public class Contract
    {
        public int IdContract { get; set; }

        public int IdTenant { get; set; }

        public int IdRoom { get; set; }

        public int IdContractStatus { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MonthlyAmount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal SecurityDeposit { get; set; }

        public DateTimeOffset RegistrationDate { get; set; }= DateTimeOffset.UtcNow;

        public string? Notes { get; set; }

        public virtual Tenant Tenant { get; set; } = null!;

        public virtual Room Room { get; set; } = null!;

        public virtual ContractStatus ContractStatus { get; set; } = null!;

        public virtual ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }

}

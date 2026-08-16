using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class Payment
    {
        public int IdPayment { get; set; }

        public int IdContract { get; set; }

        public DateTimeOffset PaymentDate { get; set; }

        public string Period { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public string PaymentMethod { get; set; }

        public bool Status { get; set; }
        public DateTimeOffset RegistrationDate { get; set; } = DateTimeOffset.UtcNow;

        public Contract contract { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class Payment
    {
        public int IdPayment { get; set; }

        public int IdContract { get; set; }

        public int IdPaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime PeriodStart { get; set; }

        public DateTime PeriodEnd { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal LateFee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        public string Status { get; set; } = null!;

        public string? Notes { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public virtual Contract Contract { get; set; } = null!;

        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
    }
}

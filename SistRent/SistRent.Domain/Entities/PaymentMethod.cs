using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class PaymentMethod
    {
        public int IdPaymentMethod { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
            = new List<Payment>();
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class ContractStatus
    {
        public int IdContractStatus { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
            = new List<Contract>();
    }
}

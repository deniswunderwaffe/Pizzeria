using System;

namespace Pizzeria.Core.Models
{
    public class PromotionalCode : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int MaximumUses { get; set; }
    }
}
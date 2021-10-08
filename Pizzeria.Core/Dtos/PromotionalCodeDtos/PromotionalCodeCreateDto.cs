using System;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Core.Dtos.PromotionalCodeDtos
{
    public class PromotionalCodeCreateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "{0} length must be exact {1} symbols", MinimumLength = 5)]
        public string Code { get; set; }

        [Required]
        [Range(0.1, 9.99, ErrorMessage = "{0} range must be between {1} and {2}")]
        public decimal Discount { get; set; }

        public bool? IsActive { get; set; }
        [Required] public DateTime ExpirationDate { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "{0} range must be between {1} and {2}")]
        public int MaximumUses { get; set; }
    }
}
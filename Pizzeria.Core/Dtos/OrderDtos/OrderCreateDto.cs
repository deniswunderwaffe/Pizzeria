using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public string PaymentOption { get; set; }
        public int? NumberOfPersons { get; set; }
        
        public List<OrderPizza> OrderPizzas { get; set; }
        public List<OrderDrink> OrderDrinks { get; set; }
    }
}
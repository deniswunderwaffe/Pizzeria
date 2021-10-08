using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Core.Dtos.CustomerDtos
{
    public class CustomerCreateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required] [EmailAddress] public string Email { get; set; }
        [Required] [Phone] public string Phone { get; set; }
        public bool? IsConfirmed { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Address { get; set; }
    }
}
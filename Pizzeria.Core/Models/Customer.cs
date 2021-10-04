
using System.Collections;
using System.Collections.Generic;

namespace Pizzeria.Core.Models
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? IsConfirmed { get; set; }
        
        public ICollection<DeliveryAddress> DeliveryAddressees { get; set; }
    }
}
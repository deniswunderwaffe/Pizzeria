namespace Pizzeria.Core.Models
{
    public class DeliveryAddress:BaseEntity
    {
        public string Street { get; set; }
        public int? Apartment { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
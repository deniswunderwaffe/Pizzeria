namespace Pizzeria.Core.Dtos.CustomerDtos
{
    public class CustomerReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? IsConfirmed { get; set; }
        public string Address { get; set; }
    }
}
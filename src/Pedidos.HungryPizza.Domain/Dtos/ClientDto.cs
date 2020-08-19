namespace Pedidos.HungryPizza.Domain.Dtos
{
    public class ClientDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
    }
}

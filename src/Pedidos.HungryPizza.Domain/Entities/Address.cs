namespace Pedidos.HungryPizza.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }        
        public string Neighborhood { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string State { get; set; }        
    }
}
namespace Pedidos.HungryPizza.Domain.Dtos
{
    public class ItemDto
    {
        public long ItemId { get; set; }
        public long OrderId { get; set; }
        public long FlavorId { get; set; }
    }
}

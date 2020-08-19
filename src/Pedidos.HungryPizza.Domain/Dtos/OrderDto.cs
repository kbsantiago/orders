using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using System.Collections.Generic;

namespace Pedidos.HungryPizza.Domain.Dtos
{
    public class OrderDto
    {
        public long Id { get; set; }
        public ClientDto Client { get; set; }        
        public decimal Total { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pedidos.HungryPizza.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Client Client { get; set; }
        public decimal Total { get; set; }
        public bool HasDeliveryTax { get; set; }
        public bool IsCheckOut { get; set; }
        public List<Item> Items { get; set; }
    }
}
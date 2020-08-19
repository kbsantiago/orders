using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.HungryPizza.Domain.Entities
{
    public class Item : BaseEntity
    {
        public long ItemId { get; set; }
        public virtual Order Order { get; set; }
        public long OrderId { get; set; }
        public virtual Flavor Flavor { get; set; }
        public long FlavorId { get; set; }
    }
}
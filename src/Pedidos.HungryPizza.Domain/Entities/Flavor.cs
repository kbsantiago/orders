using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.HungryPizza.Domain.Entities
{
    public class Flavor : BaseEntity
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
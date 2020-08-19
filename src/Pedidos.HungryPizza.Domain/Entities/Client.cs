using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.HungryPizza.Domain.Entities
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public Address Address{ get; set; } 
    }
}
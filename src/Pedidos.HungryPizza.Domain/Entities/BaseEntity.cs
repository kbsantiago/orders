using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pedidos.HungryPizza.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        #nullable enable
        private DateTime? _createdDate;
        #nullable enable
        public DateTime? CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = (value == null ? DateTime.UtcNow : value); }
        }
        private DateTime? _updatedDate;
        #nullable enable
        public DateTime? UpdatedDate
        {
            get { return _updatedDate; }
            set { _updatedDate = (value == null ? DateTime.UtcNow : value); }
        }
    }
}
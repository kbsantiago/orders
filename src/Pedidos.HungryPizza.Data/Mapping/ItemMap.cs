using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.HungryPizza.Domain.Entities;

namespace Pedidos.HungryPizza.Data.Mapping
{
    class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(p => p.Id);
                        
            builder.Property(p => p.Id)
                   .UseHiLo();
        }
    }
}

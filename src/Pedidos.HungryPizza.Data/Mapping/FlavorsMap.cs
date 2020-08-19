using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.HungryPizza.Domain.Entities;

namespace Pedidos.HungryPizza.Data.Mapping
{
    public class FlavorsMap : IEntityTypeConfiguration<Flavor>
    {
        public void Configure(EntityTypeBuilder<Flavor> builder)
        {
            builder.ToTable("Flavors");

            //builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .UseHiLo();
        }
    }
}
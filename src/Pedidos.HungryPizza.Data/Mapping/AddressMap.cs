using Microsoft.EntityFrameworkCore;
using Pedidos.HungryPizza.Domain.Entities;

namespace Pedidos.HungryPizza.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses");
            
             builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .UseHiLo();
        }
    }
}
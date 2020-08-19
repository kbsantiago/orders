using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.HungryPizza.Domain.Entities;

namespace Pedidos.HungryPizza.Data.Mapping
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .UseHiLo();

            builder.HasIndex(p => p.Document)
                   .IsUnique();

            builder.Property(p => p.Document)
                   .IsRequired()
                   .HasMaxLength(14);
            
             builder.Property(p => p.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(p => p.Email)
                   .IsUnique();

            builder.Property(p => p.MobilePhone)
                   .IsRequired()
                   .HasMaxLength(20);           

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(p => p.Address);
                  
        }
    }
}
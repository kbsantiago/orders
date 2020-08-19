using Microsoft.EntityFrameworkCore;
using Pedidos.HungryPizza.Data.Mapping;
using Pedidos.HungryPizza.Domain.Entities;
using System;

namespace Pedidos.HungryPizza.Data.Context
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Flavor> Flavors { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>(new OrderMap().Configure);
            modelBuilder.Entity<Client>(new ClientMap().Configure);
            modelBuilder.Entity<Item>(new ItemMap().Configure);
            modelBuilder.Entity<Flavor>(new FlavorsMap().Configure);
            modelBuilder.Entity<Address>(new AddressMap().Configure);

            modelBuilder.Entity<Flavor>().HasData(new Flavor() { Id = 1, CreatedDate = DateTime.Now, Name = "3 Queijos", Value = 50.00M });
            modelBuilder.Entity<Flavor>().HasData(new Flavor() { Id = 2, CreatedDate = DateTime.Now, Name = "Frango com requeijão", Value = 59.99M });
            modelBuilder.Entity<Flavor>().HasData(new Flavor() { Id = 3, CreatedDate = DateTime.Now, Name = "Mussarela", Value = 42.50M });
            modelBuilder.Entity<Flavor>().HasData(new Flavor() { Id = 4, CreatedDate = DateTime.Now, Name = "Calabresa", Value = 42.50M });
            modelBuilder.Entity<Flavor>().HasData(new Flavor() { Id = 5, CreatedDate = DateTime.Now, Name = "Pepperoni", Value = 55.00M });
            modelBuilder.Entity<Flavor>().HasData(new Flavor() { Id = 6, CreatedDate = DateTime.Now, Name = "Portuguesa", Value = 45.00M });
            modelBuilder.Entity<Flavor>().HasData(new Flavor() { Id = 7, CreatedDate = DateTime.Now, Name = "Veggie", Value = 59.99M });
        }
    }
}
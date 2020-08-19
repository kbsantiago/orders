using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Pedidos.HungryPizza.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextDb>
    {
        public ContextDb CreateDbContext(string[] args)
        {
            var connectionString = "Server=.\\;Database=Pedidos;User Id=sa;Password=novasenha";
            var optionsBuilder = new DbContextOptionsBuilder<ContextDb>();
            optionsBuilder.UseSqlServer(connectionString);
            return new ContextDb(optionsBuilder.Options);             
        }
    }
}
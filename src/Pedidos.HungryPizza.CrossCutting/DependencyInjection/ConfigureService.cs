using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pedidos.HungryPizza.Data.Context;
using Pedidos.HungryPizza.Data.Interfaces;
using Pedidos.HungryPizza.Data.Repository;
using Pedidos.HungryPizza.Data.UnitOfWork;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Interfaces;
using Pedidos.HungryPizza.Domain.Interfaces.Services;
using Pedidos.HungryPizza.Service.Services;

namespace Pedidos.HungryPizza.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependencyService(IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped<IOrderService, OrderService>();
            serviceCollection.TryAddScoped<IItemService, ItemService>();
            serviceCollection.TryAddScoped<IClientService, ClientService>();
            serviceCollection.TryAddScoped<IFlavorService, FlavorService>();
        }

        public static void RegisterRepositories(IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddScoped(typeof(IRepository<>), typeof(Repository<>));
        }

        public static void ConfigureUnitOfWork(IServiceCollection serviceColletion)
        {
            serviceColletion.TryAddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            var connectionString = "Server=.\\;Database=Pedidos;User Id=sa;Password=novasenha";

            serviceColletion.AddDbContext<ContextDb>(options => options.UseSqlServer(connectionString), ServiceLifetime.Transient, ServiceLifetime.Transient);
        }
    }
}
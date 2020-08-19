using System.Threading.Tasks;

namespace Pedidos.HungryPizza.Data.Interfaces
{
    public interface IUnitOfWork : IRepositoryFactory
    {
        Task<int> SaveAsync();
    }
}

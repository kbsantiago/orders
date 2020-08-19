using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos.HungryPizza.Domain.Entities;

namespace Pedidos.HungryPizza.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);
        void AddAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Update(TEntity entity, TEntity source);
        Task<bool> DeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(long id);
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos.HungryPizza.Data.Context;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Pedidos.HungryPizza.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ContextDb context;

        public Repository(ContextDb context) : base() =>
            this.context = context;

        public async Task<IEnumerable<TEntity>> GetAllAsync() =>
                await context.Set<TEntity>().ToListAsync();

        public Task<TEntity> GetAsync(long id) =>
            context.Set<TEntity>()
                   .FirstOrDefaultAsync(e => e.Id == id);

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Detached;
            return (await context.Set<TEntity>()
                .AddAsync(entity)).Entity;
        }

        public async void AddAsync(IEnumerable<TEntity> entities)
        {
            context.Entry(entities).State = EntityState.Detached;
            await context.Set<TEntity>()
                .AddRangeAsync(entities);
        }

        public TEntity Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Detached;
            return context.Update(entity).Entity;
        }

        public TEntity Update(TEntity entity, TEntity source)
        {
            context.Entry(entity).State = EntityState.Detached;
            var values = source.GetType()
                .GetProperties().Where(p => p.Name != "Id")
                .ToDictionary(p => p.Name, p => p.GetValue(source));
            context.Entry(entity)
                .CurrentValues
                .SetValues(values);
            return Update(entity);
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Pedidos.HungryPizza.Data.Context;
using Pedidos.HungryPizza.Data.Interfaces;
using Pedidos.HungryPizza.Data.Repository;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pedidos.HungryPizza.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextDb context;
        private readonly Dictionary<Type, object> repositories;

        public UnitOfWork(ContextDb context)
        {
            this.context = context;
            repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories.Add(typeof(TEntity),
                    new Repository<TEntity>(context));
            }
            return repositories[type] as IRepository<TEntity>;
        }

        public Task<int> SaveAsync()
        {
            var entities = context.ChangeTracker.Entries<BaseEntity>()
                 .Where(e => e.State == EntityState.Added
                     || e.State == EntityState.Modified);
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property(e => e.CreatedDate)
                        .CurrentValue = DateTime.Now;
                }
                else
                {
                    entity.Property(e => e.CreatedDate)
                        .IsModified = false;
                }
                entity.Property(e => e.UpdatedDate)
                    .CurrentValue = DateTime.Now;
            }
            return context.SaveChangesAsync();
        }
    }
}

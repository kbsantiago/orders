using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pedidos.HungryPizza.Data.Interfaces
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}

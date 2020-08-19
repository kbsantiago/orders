using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pedidos.HungryPizza.Data.Interfaces;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces;
using Pedidos.HungryPizza.Domain.Interfaces.Services;

namespace Pedidos.HungryPizza.Service.Services
{
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private IRepository<Item> repository;

        public ItemService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;                        
        }

        public Task<ItemDto> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            repository = unitOfWork.GetRepository<Item>();
            var items = await repository.GetAllAsync();
            return mapper.Map<IEnumerable<ItemDto>>(items);
        }

        public async Task<ItemDto> Save(List<ItemDto> itemDto)
        {            
            var maxItens = HasReachedMaxItensPerOrder(itemDto);
            repository = unitOfWork.GetRepository<Item>();

            if (maxItens)
            {
                foreach (var item in itemDto)
                {
                    var entity = mapper.Map<Item>(item);
                    await repository.AddAsync(entity);                   
                }
                                
                await unitOfWork.SaveAsync();
                return null;
            }
            else { throw new Exception("Max items for order has been reached."); }
        }

        public ItemDto Update(ItemDto itemDto)
        {
            throw new NotImplementedException();
        }

        private bool HasReachedMaxItensPerOrder(ICollection<ItemDto> items)
        {
            var distinctItems = items.Select(s => s.ItemId).Distinct().Count();
            return distinctItems < Constants.DefaultValues.MaxItems;
        }
    }
}
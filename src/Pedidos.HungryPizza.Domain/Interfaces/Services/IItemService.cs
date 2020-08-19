using Pedidos.HungryPizza.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.HungryPizza.Domain.Interfaces.Services
{
    public interface IItemService
    {
        Task<ItemDto> Get(long id);
        Task<IEnumerable<ItemDto>> GetAll();
        Task<ItemDto> Save(List<ItemDto> items);
        ItemDto Update(ItemDto itemDto);        
    }
}
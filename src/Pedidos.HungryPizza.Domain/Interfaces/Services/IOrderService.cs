using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;

namespace Pedidos.HungryPizza.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<OrderDto> Get(long id);
        Task<IEnumerable<OrderDto>> GetAll();
        Task<OrderDto> Create(OrderDto orderDto);
        OrderDto Update(OrderDto orderDto);
        Task<IEnumerable<OrderDto>> GetOrdersHistoryByClient(long id);
        OrderDto CheckOut(OrderDto orderDto);
    }
}
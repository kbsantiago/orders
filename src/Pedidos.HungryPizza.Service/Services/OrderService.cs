using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces.Services;
using Pedidos.HungryPizza.Domain.Dtos;
using AutoMapper;
using Pedidos.HungryPizza.Data.Interfaces;

namespace Pedidos.HungryPizza.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IClientService clientService;
        private readonly IItemService itemService;
        private readonly IFlavorService flavorService;
        
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IClientService clientService, IItemService itemService, IFlavorService flavorService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.clientService = clientService;
            this.itemService = itemService;
            this.flavorService = flavorService;            
        }

        public async Task<OrderDto> Get(long id)
        {
            var order = await unitOfWork.GetRepository<Order>().GetAsync(id);
            return mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            var orders = await unitOfWork.GetRepository<Order>().GetAllAsync();
            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> Create(OrderDto orderDto)
        {            
            var order = mapper.Map<Order>(orderDto);            
            await unitOfWork.GetRepository<Order>().AddAsync(order);
            await unitOfWork.SaveAsync();

            return mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersHistoryByClient(long id)
        {
            var orders = GetAll().Result.Where(w => w.Client.Id == id);
            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public OrderDto Update(OrderDto orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            unitOfWork.GetRepository<Order>().Update(order);
            return mapper.Map<OrderDto>(order);
        }

        public OrderDto CheckOut(OrderDto orderDto)
        {
            var items = itemService.GetAll().Result.Where(w => w.OrderId == orderDto.Id);
            var order = Get(orderDto.Id);

            decimal value = 0;
            foreach (long flavor in items.Select(s => s.FlavorId))
                value += flavorService.Get(order.Result.Id).Result.Value;

            order.Result.Total = value;

            return Update(order.Result);            
        }
    }
}
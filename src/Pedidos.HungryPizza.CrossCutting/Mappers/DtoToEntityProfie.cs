using AutoMapper;
using Pedidos.HungryPizza.Data.Repository;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace Pedidos.HungryPizza.CrossCutting.Mappers
{
    public class DtoToEntityProfie : Profile
    {
        private readonly IFlavorService flavorService;

        public DtoToEntityProfie(IFlavorService flavorService)
        {
            this.flavorService = flavorService;
        }

        public DtoToEntityProfie()
        {
            CreateMap<FlavorDto, Flavor>();
            CreateMap<ItemDto, Item>()
                .ForMember(m => m.Flavor, map => map.MapFrom(n => flavorService.Get(n.FlavorId)))
                .PreserveReferences();
            CreateMap<ICollection<ItemDto>, ICollection<Item>>();
            CreateMap<OrderDto, Order>()                
                .ForMember(v => v.Client, map => map.MapFrom(m => m.Client))                
                .PreserveReferences();
            CreateMap<AddressDto, Address>();
            CreateMap<ClientDto, Client>()
                .ForMember(v => v.Address, map => map.MapFrom(m => m.Address));
        }
    }
}
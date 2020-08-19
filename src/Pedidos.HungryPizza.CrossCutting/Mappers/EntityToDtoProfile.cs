using AutoMapper;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using System.Collections.Generic;

namespace Pedidos.HungryPizza.CrossCutting.Mappers
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Flavor, FlavorDto>();
            CreateMap<Order, OrderDto>().PreserveReferences();
            //.ForMember(v => v.Client, map => map.MapFrom(m => m.Client))
            //.ForMember(v => v.Items, map => map.MapFrom(m => m.Items));
            CreateMap<Item, ItemDto>().PreserveReferences();
                //.ForMember(m => m.FlavorId, map => map.MapFrom(n => n.Flavor.Id));
            CreateMap<ICollection<Item>, ICollection<ItemDto>>();
            CreateMap<Address, AddressDto>();
            CreateMap<Client, ClientDto>()
                .ForMember(v => v.Address, map => map.MapFrom(m => m.Address));




        }
    }
}
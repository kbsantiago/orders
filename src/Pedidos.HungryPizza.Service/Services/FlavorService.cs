using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pedidos.HungryPizza.Data.Interfaces;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces;
using Pedidos.HungryPizza.Domain.Interfaces.Services;

namespace Pedidos.HungryPizza.Service.Services
{
    public class FlavorService : IFlavorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FlavorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork; ;
            this.mapper = mapper;
        }

        public async Task<FlavorDto> Get(long id)
        {
            var flavor = await unitOfWork.GetRepository<Flavor>().GetAsync(id);
            return mapper.Map<FlavorDto>(flavor);
        }

        public async Task<IEnumerable<FlavorDto>> GetAll()
        {          
            var flavors = await unitOfWork.GetRepository<Flavor>().GetAllAsync();         
            return mapper.Map<IEnumerable<FlavorDto>>(flavors);
        }

        public Task<FlavorDto> Save(FlavorDto flavorDto)
        {
            throw new NotImplementedException();
        }

        public FlavorDto Update(FlavorDto flavorDto)
        {
            throw new NotImplementedException();
        }
    }
}
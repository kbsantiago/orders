using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Pedidos.HungryPizza.Data.Interfaces;
using Pedidos.HungryPizza.Domain.Dtos;
using Pedidos.HungryPizza.Domain.Entities;
using Pedidos.HungryPizza.Domain.Interfaces.Services;

namespace Pedidos.HungryPizza.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {            
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ClientDto> Get(long id)
        {
            var client = await unitOfWork.GetRepository<Client>().GetAsync(id);
            return mapper.Map<ClientDto>(client);
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            var clients = await unitOfWork.GetRepository<Client>().GetAllAsync();
            return mapper.Map<IEnumerable<ClientDto>>(clients);
        }

        public async Task<ClientDto> Save(ClientDto clientDto)
        {
            var client = mapper.Map<Client>(clientDto);
            client = await unitOfWork.GetRepository<Client>().AddAsync(client);
            return mapper.Map<ClientDto>(client);
        }

        public ClientDto Update(ClientDto clientDto)
        {
            var client = mapper.Map<Client>(clientDto);
            unitOfWork.GetRepository<Client>().Update(client);
            return clientDto;
        }
    }
}
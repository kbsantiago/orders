using Pedidos.HungryPizza.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.HungryPizza.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<ClientDto> Get(long id);
        Task<IEnumerable<ClientDto>> GetAll();
        Task<ClientDto> Save(ClientDto clientDto);
        ClientDto Update(ClientDto clientDto);
    }
}
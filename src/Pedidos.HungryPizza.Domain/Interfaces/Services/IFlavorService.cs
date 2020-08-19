using Pedidos.HungryPizza.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pedidos.HungryPizza.Domain.Interfaces.Services
{
    public interface IFlavorService
    {
        Task<FlavorDto> Get(long id);
        Task<IEnumerable<FlavorDto>> GetAll();
        Task<FlavorDto> Save(FlavorDto flavorDto);
        FlavorDto Update(FlavorDto flavorDto);
    }
}
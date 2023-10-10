using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services
{
    public interface IClienteService
    {
        Task<Cliente> Create(ClienteDto newCliente);
        Task Delete(int id);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente?> GetById(int id);
        Task Update(int id, ClienteDto cliente);
    }
}
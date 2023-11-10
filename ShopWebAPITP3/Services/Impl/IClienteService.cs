using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services.Impl
{
    public interface IClienteService
    {
        Task<Cliente> Create(ClienteDtoIn newCliente);
        Task Delete(int id);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente?> GetById(int id);
        Task Update(int id, ClienteDtoIn cliente);
    }
}
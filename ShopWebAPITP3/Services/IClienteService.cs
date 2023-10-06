using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services
{
    public interface IClienteService
    {
        Task<Cliente> Create(Cliente newCliente);
        Task Delete(int id);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente?> GetById(int id);
        Task Update(int id, Cliente cliente);
    }
}
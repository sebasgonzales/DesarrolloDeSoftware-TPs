using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services
{
    public interface ICategoriaService
    {
        Task<Categoria> Create(Categoria newCategoria);
        Task Delete(int id);
        Task<IEnumerable<Categoria>> GetAll();
        Task<Categoria?> GetById(int id);
        Task Update(int id, Categoria categoria);
    }
}
using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services
{
    public interface ICategoriaService
    {
        Task<Categoria> Create(CategoriaDtoIn newCategoria);
        Task Delete(int id);
        Task<IEnumerable<CategoriaDtoOut>> GetAll();
        Task<Categoria?> GetById(int id);
        Task Update(int id, CategoriaDtoIn categoria);
    }
}
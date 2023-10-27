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
        Task<CategoriaDtoOut?> GetDtoById(int id);
        Task<IEnumerable<CategoriaDtoOut?>> GetProductsByCategory(string nombre);
        Task Update(int id, CategoriaDtoIn categoria);
    }
}
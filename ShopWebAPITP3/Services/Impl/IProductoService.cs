using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services.Impl
{
    public interface IProductoService
    {
        Task<Producto> Create(ProductoDtoIn newProducto);
        Task Delete(int id);
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto?> GetById(int id);
        Task Update(int id, ProductoDtoIn producto);
    }
}
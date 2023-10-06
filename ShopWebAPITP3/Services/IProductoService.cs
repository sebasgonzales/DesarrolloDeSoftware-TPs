using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services
{
    public interface IProductoService
    {
        Task<Producto> Create(Producto newProducto);
        Task Delete(int id);
        Task<IEnumerable<Producto>> GetAll();
        Task<Producto?> GetById(int id);
        Task Update(int id, Producto producto);
    }
}
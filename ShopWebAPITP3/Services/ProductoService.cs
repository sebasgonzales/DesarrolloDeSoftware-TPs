using Microsoft.EntityFrameworkCore;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services;

public class ProductoService
{
    private readonly ShopContext _context;

    public ProductoService(ShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAll()
    {
        return await _context.Producto
            .Include(p => p.categoria)
            .ToListAsync();
    }

    public async Task<Producto?> GetById (int id)
    {
        return await _context.Producto.FindAsync(id);
    }

    public async Task<Producto> Create(Producto newProducto)
    {
        _context.Producto.Add(newProducto);
        await _context.SaveChangesAsync();

        return newProducto;
    }

    public async Task Update (int id, Producto producto)
    {
        var existingProduct = await GetById(id);

        if (existingProduct is not null)
        {
            existingProduct.Nombre = producto.Nombre;
            existingProduct.Descripcion = producto.Descripcion;
            existingProduct.PrecioUnitario = producto.PrecioUnitario;
            existingProduct.Stock = producto.Stock;
            existingProduct.IdCategoria = producto.IdCategoria;

            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete (int id)
    {
        var productToDelete = await GetById(id);
        if (productToDelete is not null)
        {
            _context.Producto.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
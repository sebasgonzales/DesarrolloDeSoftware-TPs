using Microsoft.EntityFrameworkCore;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services;

public class ProductoService : IProductoService
{
    private readonly ShopContext _context;

    public ProductoService(ShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAll()
    {
        return await _context.Producto
            .Include(p => p.CategoriaNavegacion)
            .ToListAsync();
    }

    public async Task<Producto?> GetById(int id)
    {
        var producto = await _context.Producto
                .Include(p => p.CategoriaNavegacion)
                .Where(p => p.IdProducto == id)
                .SingleOrDefaultAsync();
        return producto;
    }





    public async Task<Producto> Create(ProductoDtoIn newProductoDto)
    {
        var newProducto = new Producto();

        newProducto.Nombre = newProductoDto.Nombre;
        newProducto.Descripcion = newProductoDto.Descripcion;
        newProducto.PrecioUnitario = newProductoDto.PrecioUnitario;
        newProducto.Stock = newProductoDto.Stock;
        newProducto.IdCategoria = newProductoDto.IdCategoria;

        _context.Producto.Add(newProducto);
        await _context.SaveChangesAsync();

        return newProducto;
    }

    public async Task Update(int id, ProductoDtoIn producto)
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

    public async Task Delete(int id)
    {
        var productToDelete = await GetById(id);
        if (productToDelete is not null)
        {
            _context.Producto.Remove(productToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
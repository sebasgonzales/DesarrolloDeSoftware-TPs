using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopWebAPITP3.Services
{
    public class CategoriaService
    {
        private readonly ShopContext _context;

        public CategoriaService(ShopContext context)
        {
            _context = context;
        }

        //Defino métodos en mi servicio que va a replicar las acciones en el Controller en mi servicio

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Categoria?> GetById(int id) // Puede devolver o no un Categoria
        {
            return await _context.Categoria.FindAsync(id);
        }

        public async Task<Categoria> Create(Categoria newCategoria)
        {
            _context.Categoria.Add(newCategoria);
            await _context.SaveChangesAsync();

            return newCategoria;
        }

        public async Task Update(int id, Categoria Categoria)
        {
            var existingCategory = await GetById(id);

            if (existingCategory is not null)
            {
                existingCategory.Nombre = Categoria.Nombre;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var categoryToDelete = await GetById(id);
            if (categoryToDelete is not null)
            {
                _context.Categoria.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}


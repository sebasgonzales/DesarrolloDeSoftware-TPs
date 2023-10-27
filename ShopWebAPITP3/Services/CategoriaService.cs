using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Data.DTOs;

namespace ShopWebAPITP3.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ShopContext _context;

        public CategoriaService(ShopContext context)
        {
            _context = context;
        }

        //Defino métodos en mi servicio que va a replicar las acciones en el Controller en mi servicio

        public async Task<IEnumerable<CategoriaDtoOut>> GetAll()
        {
            return await _context.Categoria
                .Include(c => c.Productos)
                .Select(c => new CategoriaDtoOut
            {
                Nombre = c.Nombre != null ? c.Nombre : "",
                Productos = c.Productos.ToList()

                }).ToListAsync();
        }

        public async Task<CategoriaDtoOut?> GetDtoById(int id) // Puede devolver o no un Categoria
        {
            return await _context.Categoria
                .Where (c => c.IdCategoria == id)
                .Select(c => new CategoriaDtoOut
            {
                Nombre = c.Nombre != null ? c.Nombre : ""
            }).SingleOrDefaultAsync();
        }

        public async Task<Categoria?> GetById(int id) // Puede devolver o no un Categoria
        {
            // Convertir el IQueryable<Categoria> a un Categoria
            var categoria = await _context.Categoria
                .Include(c => c.Productos)
                .Where(c => c.IdCategoria == id)
                .SingleOrDefaultAsync();

            // Devolver la categoría
            return categoria;
        }

        public async Task<IEnumerable<CategoriaDtoOut?>> GetProductsByCategory(string nombre)
        {
            return await _context.Categoria
            .Where(c => c.Nombre == nombre)
            //.Include(c => c.Productos)
            .Select(c => new CategoriaDtoOut
            {
                Productos = c.Productos.Select(p => p.Nombre).ToList()
            }).ToListAsync();
        }

        public async Task<Categoria> Create(CategoriaDtoIn newCategoriaDto)
        {
            var newCategoria = new Categoria();
            newCategoria.Nombre = newCategoriaDto.Nombre;

            _context.Categoria.Add(newCategoria);
            await _context.SaveChangesAsync();

            return newCategoria;
        }


        public async Task Update(int id, CategoriaDtoIn categoria)
        {
            var existingCategory = await GetById(id);

            if (existingCategory is not null)
            {
                existingCategory.Nombre = categoria.Nombre;

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


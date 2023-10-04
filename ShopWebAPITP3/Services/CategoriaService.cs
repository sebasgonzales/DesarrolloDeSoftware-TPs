﻿using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
            return await _context.Categoria     //Enlanza a Productos y muestra en un array todos los productos que tienen esa categoria
            .Include(c => c.Productos)
            .ToListAsync();
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
        public async Task<Categoria> Create(Categoria newCategoria)
        {
            _context.Categoria.Add(newCategoria);
            await _context.SaveChangesAsync();

            return newCategoria;
        }

        public async Task Update(int id, Categoria categoria)
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

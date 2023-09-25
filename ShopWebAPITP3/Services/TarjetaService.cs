using Microsoft.EntityFrameworkCore;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services;

public class TarjetaService
{
    private readonly ShopContext _context;

    public TarjetaService(ShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tarjeta>> GetAll()
    {
        return await _context.Tarjeta.ToListAsync();
    }

    public async Task<Tarjeta?> GetById (int id)
    {
        return await _context.Tarjeta.FindAsync(id);
    }

    public async Task<Tarjeta> Create(Tarjeta newTarjeta)
    {
        _context.Tarjeta.Add(newTarjeta);
        await _context.SaveChangesAsync();

        return newTarjeta;
    }

    public async Task Update (int id, Tarjeta Tarjeta)
    {
        var existingTarjeta = await GetById(id);

        if (existingTarjeta is not null)
        {
            existingTarjeta.Nombre = Tarjeta.Nombre;
            existingTarjeta.Tipo = Tarjeta.Tipo;
            existingTarjeta.NumeroTarjeta = Tarjeta.NumeroTarjeta;
            existingTarjeta.Vencimiento = Tarjeta.Vencimiento;
            existingTarjeta.Cvv = Tarjeta.Cvv;

            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete (int id)
    {
        var TarjetaToDelete = await GetById(id);
        if (TarjetaToDelete is not null)
        {
            _context.Tarjeta.Remove(TarjetaToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
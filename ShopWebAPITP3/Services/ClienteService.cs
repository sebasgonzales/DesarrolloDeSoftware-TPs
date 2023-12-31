using Microsoft.EntityFrameworkCore;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Services.Impl;

namespace ShopWebAPITP3.Services;
public class ClienteService : IClienteService
{
    private readonly ShopContext _context;

    public ClienteService(ShopContext context)
    {
        _context = context;
    }

    //Defino métodos en mi servicio que va a replicar las acciones en el Controller en mi servicio

    public async Task<IEnumerable<Cliente>> GetAll()
    {
        return await _context.Cliente.ToListAsync();
    }

    public async Task<Cliente?> GetById(int id) // Puede devolver o no un Cliente
    {
        return await _context.Cliente.FindAsync(id);
    }

    public async Task<Cliente> Create(ClienteDtoIn newClienteDto)
    {
        var newCliente = new Cliente();
        newCliente.Nombre = newClienteDto.Nombre;
        newCliente.Apellido = newClienteDto.Apellido;
        newCliente.Direccion = newClienteDto.Direccion;
        newCliente.Telefono = newClienteDto.Telefono;
        newCliente.Genero = newClienteDto.Genero;

        _context.Cliente.Add(newCliente);
        await _context.SaveChangesAsync();

        return newCliente;
    }

    public async Task Update(int id, ClienteDtoIn cliente)
    {
        var existingClient = await GetById(id);

        if (existingClient is not null)
        {
            existingClient.Nombre = cliente.Nombre;
            existingClient.Apellido = cliente.Apellido;
            existingClient.Direccion = cliente.Direccion;
            existingClient.Telefono = cliente.Telefono;
            existingClient.Genero = cliente.Genero;

            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var clientToDelete = await GetById(id);
        if (clientToDelete is not null)
        {
            _context.Cliente.Remove(clientToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services;

public class TicketService
{
    private readonly ShopContext _context;

    public TicketService(ShopContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ticket>> GetAll()
    {
        return await _context.Ticket.ToListAsync();
    }

    public async Task<Ticket?> GetById (int id)
    {
        return await _context.Ticket.FindAsync(id);
    }

    public async Task<Ticket> Create(Ticket newTicket)
    {
        _context.Ticket.Add(newTicket);
        await _context.SaveChangesAsync();

        return newTicket;
    }

    public async Task Update (int id, Ticket Ticket)
    {
        var existingTicket = await GetById(id);

        if (existingTicket is not null)
        {
            existingTicket.Fecha = Ticket.Fecha;
            existingTicket.IdCliente = Ticket.IdCliente;
            existingTicket.Total = Ticket.Total;
            existingTicket.IdProducto = Ticket.IdProducto;

            await _context.SaveChangesAsync();
        }
    }

    public async Task Delete (int id)
    {
        var TicketToDelete = await GetById(id);
        if (TicketToDelete is not null)
        {
            _context.Ticket.Remove(TicketToDelete);
            await _context.SaveChangesAsync();
        }
    }
}
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
         return await _context.Ticket
            .Include(t => t.TicketDetalles)
            .ThenInclude(td => td.Productos)
            .Include(t => t.Cliente)
            .ToListAsync();
            
    }

    public async Task<Ticket?> GetById (int id)
    {
        // Convertir el IQueryable<Ticket> a un Ticket
        var ticket = await _context.Ticket
            .Include(t => t.TicketDetalles)
            .Include(t => t.Cliente)
            .Where(t => t.IdTicket == id)
            .SingleOrDefaultAsync();

        // Devolver la Ticket
        return ticket;
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
            existingTicket.Total = Ticket.Total;
            existingTicket.IdCliente = Ticket.IdCliente;

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
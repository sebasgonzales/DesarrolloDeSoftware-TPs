using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Data;
using Microsoft.EntityFrameworkCore;

namespace ShopWebAPITP3.Services
{
    public class TicketDetalleService
    {
        private readonly ShopContext _context;

        public TicketDetalleService(ShopContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TicketDetalle>> GetAll()
        {
            return await _context.TicketDetalle.ToListAsync();
        }

        public async Task<TicketDetalle?> GetById(int id)
        {
            return await _context.TicketDetalle.FindAsync(id);
        }

        public async Task<TicketDetalle> Create(TicketDetalle newTicketDetalle)
        {
            _context.TicketDetalle.Add(newTicketDetalle);
            await _context.SaveChangesAsync();

            return newTicketDetalle;
        }

        public async Task Update(int id, TicketDetalle TicketDetalle)
        {
            var existingTicketDetail = await GetById(id);

            if (existingTicketDetail is not null)
            {
                existingTicketDetail.PrecioUnitario = TicketDetalle.PrecioUnitario;
                existingTicketDetail.Cantidad = TicketDetalle.Cantidad;
                existingTicketDetail.IdProducto = TicketDetalle.IdProducto;
                existingTicketDetail.IdTicket = TicketDetalle.IdTicket;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var ticketDetailToDelete = await GetById(id);
            if (ticketDetailToDelete is not null)
            {
                _context.TicketDetalle.Remove(ticketDetailToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

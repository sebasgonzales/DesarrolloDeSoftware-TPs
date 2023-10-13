using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services
{
    public interface ITicketService
    {
        Task<Ticket> Create(TicketDtoIn newTicket);
        Task Delete(int id);
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(int id);
        Task Update(int id, TicketDtoIn Ticket);
    }
}
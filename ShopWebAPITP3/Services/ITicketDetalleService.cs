using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services
{
    public interface ITicketDetalleService
    {
        Task<TicketDetalle> Create(TicketDetalle newTicketDetalle);
        Task Delete(int id);
        Task<IEnumerable<TicketDetalle>> GetAll();
        Task<TicketDetalle?> GetById(int id);
        Task Update(int id, TicketDetalle TicketDetalle);
    }
}
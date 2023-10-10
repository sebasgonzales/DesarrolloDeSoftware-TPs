namespace ShopWebAPITP3.Data.DTOs
{
    public class TicketDto
    {
        public int IdTicket { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
    }
}

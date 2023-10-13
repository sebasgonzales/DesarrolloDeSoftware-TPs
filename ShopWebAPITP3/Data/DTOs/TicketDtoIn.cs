namespace ShopWebAPITP3.Data.DTOs
{
    public class TicketDtoIn
    {
        public int IdTicket { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
    }
}

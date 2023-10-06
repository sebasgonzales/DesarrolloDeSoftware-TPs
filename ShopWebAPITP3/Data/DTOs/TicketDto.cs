namespace ShopWebAPITP3.Data.Dto
{
    public class TicketDto
    {
        public int idTicket { get; set; }
        public DateTime fecha { get; set; }
        public decimal total { get; set; }
        public int idCliente { get; set; }
        public List<TicketDetalleDto> TicketDetalles { get; set; }
    }
}

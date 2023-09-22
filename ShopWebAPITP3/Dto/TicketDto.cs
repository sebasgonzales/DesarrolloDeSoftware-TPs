namespace ShopWebAPITP3.Dto
{
    public class TicketDto
    {
        public int idTicket { get; set; }
        public DateTime fecha { get; set; }

        public int IdCliente { get; set; }
        public List<ProductoDto> Productos { get; set; }
        public decimal Total { get; set; }
    }
}

namespace ShopWebAPITP3.Data.DTOs
{
    public class TicketDetalleDtoIn
    {
        public int IdTicketDetalle { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int IdTicket { get; set; }

    }
}

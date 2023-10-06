using ShopWebAPITP3.Data.ShopModels;


namespace ShopWebAPITP3.Data.Dto
{
    public class TicketDetalleDto
    {
        public int idTicketDetalle { get; set; }
        public decimal precioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int idProducto { get; set; }
        public int idTicket { get; set; }

    }
}

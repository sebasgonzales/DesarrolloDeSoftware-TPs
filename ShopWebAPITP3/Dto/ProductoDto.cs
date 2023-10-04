namespace ShopWebAPITP3.Dto
{
    public class ProductoDto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal precioUnitario { get; set; }
        public int idCategoria { get; set; }
    }
}

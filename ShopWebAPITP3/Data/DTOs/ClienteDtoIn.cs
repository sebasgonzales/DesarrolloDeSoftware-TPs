namespace ShopWebAPITP3.Data.DTOs
{
    public class ClienteDtoIn
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Genero { get; set; }

    }
}

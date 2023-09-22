namespace ShopWebAPITP3.Dto
{
    public class Tarjeta
    {
        public int idTarjeta { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; } = "Tarjeta de crédito";
        public string numeroTarjeta { get; set; }
        public string fechaCaducidad { get; set; }
        public string cvv { get; set; }
    }
}

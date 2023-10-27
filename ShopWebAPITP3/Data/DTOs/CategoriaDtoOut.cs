using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Data.DTOs
{
    public class CategoriaDtoOut
    {
        //public int ID { get; set; }
        public string Nombre { get; set; }
        public List<Producto>? Productos { get; set; }

    }
}

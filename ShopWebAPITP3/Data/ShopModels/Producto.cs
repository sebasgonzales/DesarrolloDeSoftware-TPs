using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }
        [MaxLength(40)]
        public string? Nombre { get; set; }
        [MaxLength(40)]
        public string? Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}

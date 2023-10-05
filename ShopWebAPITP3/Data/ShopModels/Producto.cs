using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


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
        public decimal PrecioUnitario { get; set; }
        [ForeignKey("IdCategoria")]

        public int IdCategoria {  get; set; }
        [JsonIgnore]
        public virtual Categoria? categorias { get; set; } //Navegación
    }
}

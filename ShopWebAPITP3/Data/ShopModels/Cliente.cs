using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        [MaxLength(40)]
        public string? Nombre { get; set; }
        [MaxLength(40)]
        public string? Apellido { get; set; }
        [MaxLength(40)]
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Genero { get; set; }
    }
}

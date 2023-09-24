using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class Tarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTarjeta { get; set; }
        [MaxLength(40)]
        public string? Nombre { get; set; }
        [MaxLength(40)]
        public string? Tipo { get; set; }
        public string? NumeroTarjeta { get; set; }
        public string? Vencimiento { get; set; }
        public string? Cvv { get; set; }
    }
}

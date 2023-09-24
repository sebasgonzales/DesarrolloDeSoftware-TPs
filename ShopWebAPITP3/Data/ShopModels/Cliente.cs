using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCliente { get; set; }
        [MaxLength(40)]
        public string Nombre { get; set; }
        [MaxLength(40)]
        public string Apellidos { get; set; }
        [MaxLength(40)]
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        [ForeignKey("IdTarjeta")]
        public virtual Tarjeta? Tarjeta {get;set;}

    }
}

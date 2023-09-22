using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class Tarjeta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTarjeta { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string numeroTarjeta { get; set; }
        public string fechaCaducidad { get; set; }
        public string cvv { get; set; }
    }
}

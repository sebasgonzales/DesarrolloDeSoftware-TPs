using ShopWebAPITP3.Dto;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTicket { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }
        public int Cantidad {get;set;}
        public decimal Total { get; set; }
        public int IdProducto { get; set; }
        [JsonIgnore]
        [ForeignKey("IdProducto")]

        public virtual Producto? Producto { get; set; } //Navegacion


        [JsonIgnore]
        public virtual ICollection<Producto>? Productos { get; set; }

    }
}

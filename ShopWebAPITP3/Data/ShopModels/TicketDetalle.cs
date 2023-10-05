using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class TicketDetalle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTicketDetalle { get; set; }
        public decimal PrecioUnitario {  get; set; }
        public int Cantidad {  get; set; }
        [ForeignKey("IdProducto")]
        public int IdProducto { get; set; }
        [ForeignKey("IdTicket")]
        public int IdTicket { get; set; }
        public virtual Producto? Productos { get; set; } //NOT NULL Navegacion
        public virtual Ticket? Tickets { get; set; } //NOT NULL Navegacion
    }
}

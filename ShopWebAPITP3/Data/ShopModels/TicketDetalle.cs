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
        public int IdProducto { get; set; }
        public int IdTicket { get; set; }
        [ForeignKey("IdProducto")]
        public virtual Producto? Productos { get; set; } //NOT NULL Navegacion
        [ForeignKey("IdTicket")]
        public virtual Ticket? Tickets { get; set; } //NOT NULL Navegacion
    }
}

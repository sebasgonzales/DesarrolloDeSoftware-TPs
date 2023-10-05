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
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; } // Navegación para FK
        public virtual ICollection<TicketDetalle>? TicketDetalles { get; set; }

    }
}

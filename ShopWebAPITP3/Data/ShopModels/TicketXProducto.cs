using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopWebAPITP3.Data.ShopModels
{
    public class TicketXProducto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTicketXProducto { get; set; }
        public Ticket ticket { get; set; }
        public Producto producto { get; set; }
    }
}

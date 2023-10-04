using Microsoft.EntityFrameworkCore;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)

        {
        }
        // Es Para que las clases se mapeen en tipo entidad en nuestra BD aunque esta no exista
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<TicketDetalle> TicketDetalle { get; set; }

    }
}

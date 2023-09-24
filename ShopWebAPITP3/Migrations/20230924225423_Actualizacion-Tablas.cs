using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopWebAPITP3.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Ticket_TicketidOrden",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "TicketXProductos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "fecha",
                table: "Ticket",
                newName: "Fecha");

            migrationBuilder.RenameColumn(
                name: "idOrden",
                table: "Ticket",
                newName: "Cantidad");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Tarjeta",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "numeroTarjeta",
                table: "Tarjeta",
                newName: "NumeroTarjeta");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Tarjeta",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "cvv",
                table: "Tarjeta",
                newName: "Cvv");

            migrationBuilder.RenameColumn(
                name: "idTarjeta",
                table: "Tarjeta",
                newName: "IdTarjeta");

            migrationBuilder.RenameColumn(
                name: "fechaCaducidad",
                table: "Tarjeta",
                newName: "Vencimiento");

            migrationBuilder.RenameColumn(
                name: "precio",
                table: "Producto",
                newName: "Precio");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Producto",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "descripcion",
                table: "Producto",
                newName: "Descripcion");

            migrationBuilder.RenameColumn(
                name: "idProducto",
                table: "Producto",
                newName: "IdProducto");

            migrationBuilder.RenameColumn(
                name: "TicketidOrden",
                table: "Producto",
                newName: "TicketIdTicket");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_TicketidOrden",
                table: "Producto",
                newName: "IX_Producto_TicketIdTicket");

            migrationBuilder.RenameColumn(
                name: "telefono",
                table: "Cliente",
                newName: "Telefono");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Cliente",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "direccion",
                table: "Cliente",
                newName: "Direccion");

            migrationBuilder.RenameColumn(
                name: "apellidos",
                table: "Cliente",
                newName: "Apellidos");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Cliente",
                newName: "IdCliente");

            migrationBuilder.AlterColumn<int>(
                name: "Cantidad",
                table: "Ticket",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "IdTicket",
                table: "Ticket",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Tarjeta",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Tarjeta",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Producto",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Producto",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Cliente",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Direccion",
                table: "Cliente",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "Cliente",
                type: "character varying(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "IdTarjeta",
                table: "Cliente",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdTarjeta",
                table: "Cliente",
                column: "IdTarjeta");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Tarjeta_IdTarjeta",
                table: "Cliente",
                column: "IdTarjeta",
                principalTable: "Tarjeta",
                principalColumn: "IdTarjeta");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Ticket_TicketIdTicket",
                table: "Producto",
                column: "TicketIdTicket",
                principalTable: "Ticket",
                principalColumn: "IdTicket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Tarjeta_IdTarjeta",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Ticket_TicketIdTicket",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdTarjeta",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "IdTicket",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "IdTarjeta",
                table: "Cliente");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Ticket",
                newName: "fecha");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Ticket",
                newName: "idOrden");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Tarjeta",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "NumeroTarjeta",
                table: "Tarjeta",
                newName: "numeroTarjeta");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Tarjeta",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Cvv",
                table: "Tarjeta",
                newName: "cvv");

            migrationBuilder.RenameColumn(
                name: "IdTarjeta",
                table: "Tarjeta",
                newName: "idTarjeta");

            migrationBuilder.RenameColumn(
                name: "Vencimiento",
                table: "Tarjeta",
                newName: "fechaCaducidad");

            migrationBuilder.RenameColumn(
                name: "Precio",
                table: "Producto",
                newName: "precio");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Producto",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Producto",
                newName: "descripcion");

            migrationBuilder.RenameColumn(
                name: "IdProducto",
                table: "Producto",
                newName: "idProducto");

            migrationBuilder.RenameColumn(
                name: "TicketIdTicket",
                table: "Producto",
                newName: "TicketidOrden");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_TicketIdTicket",
                table: "Producto",
                newName: "IX_Producto_TicketidOrden");

            migrationBuilder.RenameColumn(
                name: "Telefono",
                table: "Cliente",
                newName: "telefono");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Cliente",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Direccion",
                table: "Cliente",
                newName: "direccion");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "Cliente",
                newName: "apellidos");

            migrationBuilder.RenameColumn(
                name: "IdCliente",
                table: "Cliente",
                newName: "idCliente");

            migrationBuilder.AlterColumn<int>(
                name: "idOrden",
                table: "Ticket",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "Tarjeta",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Tarjeta",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Producto",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "descripcion",
                table: "Producto",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "Cliente",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "direccion",
                table: "Cliente",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "apellidos",
                table: "Cliente",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(40)",
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "idOrden");

            migrationBuilder.CreateTable(
                name: "TicketXProductos",
                columns: table => new
                {
                    idTicketXProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productoidProducto = table.Column<int>(type: "integer", nullable: false),
                    ticketidOrden = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketXProductos", x => x.idTicketXProducto);
                    table.ForeignKey(
                        name: "FK_TicketXProductos_Producto_productoidProducto",
                        column: x => x.productoidProducto,
                        principalTable: "Producto",
                        principalColumn: "idProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketXProductos_Ticket_ticketidOrden",
                        column: x => x.ticketidOrden,
                        principalTable: "Ticket",
                        principalColumn: "idOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketXProductos_productoidProducto",
                table: "TicketXProductos",
                column: "productoidProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TicketXProductos_ticketidOrden",
                table: "TicketXProductos",
                column: "ticketidOrden");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Ticket_TicketidOrden",
                table: "Producto",
                column: "TicketidOrden",
                principalTable: "Ticket",
                principalColumn: "idOrden");
        }
    }
}

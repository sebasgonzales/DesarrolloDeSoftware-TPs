using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopWebAPITP3.Migrations
{
    /// <inheritdoc />
    public partial class InitBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Apellido = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Direccion = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    Genero = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    PrecioUnitario = table.Column<decimal>(type: "numeric", nullable: false),
                    IdCategoria = table.Column<int>(type: "integer", nullable: false),
                    categoriasIdCategoria = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_categoriasIdCategoria",
                        column: x => x.categoriasIdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    ClienteIdCliente = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_Cliente_ClienteIdCliente",
                        column: x => x.ClienteIdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateTable(
                name: "TicketDetalle",
                columns: table => new
                {
                    IdTicketDetalle = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PrecioUnitario = table.Column<decimal>(type: "numeric", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    IdProducto = table.Column<int>(type: "integer", nullable: false),
                    IdTicket = table.Column<int>(type: "integer", nullable: false),
                    ProductosIdProducto = table.Column<int>(type: "integer", nullable: true),
                    TicketsIdTicket = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetalle", x => x.IdTicketDetalle);
                    table.ForeignKey(
                        name: "FK_TicketDetalle_Producto_ProductosIdProducto",
                        column: x => x.ProductosIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_TicketDetalle_Ticket_TicketsIdTicket",
                        column: x => x.TicketsIdTicket,
                        principalTable: "Ticket",
                        principalColumn: "IdTicket");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producto_categoriasIdCategoria",
                table: "Producto",
                column: "categoriasIdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ClienteIdCliente",
                table: "Ticket",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetalle_ProductosIdProducto",
                table: "TicketDetalle",
                column: "ProductosIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetalle_TicketsIdTicket",
                table: "TicketDetalle",
                column: "TicketsIdTicket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketDetalle");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}

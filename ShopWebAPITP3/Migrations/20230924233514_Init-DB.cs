using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShopWebAPITP3.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    IdTarjeta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Tipo = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    NumeroTarjeta = table.Column<string>(type: "text", nullable: true),
                    Vencimiento = table.Column<string>(type: "text", nullable: true),
                    Cvv = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.IdTarjeta);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Apellidos = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Direccion = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Telefono = table.Column<string>(type: "text", nullable: true),
                    IdTarjeta = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Tarjeta_IdTarjeta",
                        column: x => x.IdTarjeta,
                        principalTable: "Tarjeta",
                        principalColumn: "IdTarjeta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Descripcion = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Precio = table.Column<decimal>(type: "numeric", nullable: false),
                    TicketIdTicket = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    IdTicket = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IdCliente = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    IdProducto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdTarjeta",
                table: "Cliente",
                column: "IdTarjeta");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TicketIdTicket",
                table: "Producto",
                column: "TicketIdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdCliente",
                table: "Ticket",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_IdProducto",
                table: "Ticket",
                column: "IdProducto");

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

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}

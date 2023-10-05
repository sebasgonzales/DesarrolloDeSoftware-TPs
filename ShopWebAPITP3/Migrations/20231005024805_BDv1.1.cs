﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopWebAPITP3.Migrations
{
    /// <inheritdoc />
    public partial class BDv11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Producto",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Producto");
        }
    }
}

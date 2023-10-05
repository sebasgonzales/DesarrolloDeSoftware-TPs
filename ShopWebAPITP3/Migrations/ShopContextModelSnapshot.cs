﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ShopWebAPITP3.Data;

#nullable disable

namespace ShopWebAPITP3.Migrations
{
    [DbContext(typeof(ShopContext))]
    partial class ShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Genero")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("Telefono")
                        .HasColumnType("text");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("Descripcion")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("integer");

                    b.Property<string>("Nombre")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("numeric");

                    b.Property<int?>("categoriasIdCategoria")
                        .HasColumnType("integer");

                    b.HasKey("IdProducto");

                    b.HasIndex("categoriasIdCategoria");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Ticket", b =>
                {
                    b.Property<int>("IdTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTicket"));

                    b.Property<int?>("ClienteIdCliente")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdCliente")
                        .HasColumnType("integer");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.HasKey("IdTicket");

                    b.HasIndex("ClienteIdCliente");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.TicketDetalle", b =>
                {
                    b.Property<int>("IdTicketDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdTicketDetalle"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("integer");

                    b.Property<int>("IdProducto")
                        .HasColumnType("integer");

                    b.Property<int>("IdTicket")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("numeric");

                    b.Property<int?>("ProductosIdProducto")
                        .HasColumnType("integer");

                    b.Property<int?>("TicketsIdTicket")
                        .HasColumnType("integer");

                    b.HasKey("IdTicketDetalle");

                    b.HasIndex("ProductosIdProducto");

                    b.HasIndex("TicketsIdTicket");

                    b.ToTable("TicketDetalle");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Producto", b =>
                {
                    b.HasOne("ShopWebAPITP3.Data.ShopModels.Categoria", "categorias")
                        .WithMany("Productos")
                        .HasForeignKey("categoriasIdCategoria");

                    b.Navigation("categorias");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Ticket", b =>
                {
                    b.HasOne("ShopWebAPITP3.Data.ShopModels.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteIdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.TicketDetalle", b =>
                {
                    b.HasOne("ShopWebAPITP3.Data.ShopModels.Producto", "Productos")
                        .WithMany()
                        .HasForeignKey("ProductosIdProducto");

                    b.HasOne("ShopWebAPITP3.Data.ShopModels.Ticket", "Tickets")
                        .WithMany("TicketDetalles")
                        .HasForeignKey("TicketsIdTicket");

                    b.Navigation("Productos");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("ShopWebAPITP3.Data.ShopModels.Ticket", b =>
                {
                    b.Navigation("TicketDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿namespace ShopWebAPITP3.Data.DTOs
{
    public class ClienteDto
    {
        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string? direccion { get; set; }
        public string? telefono { get; set; }
        public string? genero { get; set; }

    }
}

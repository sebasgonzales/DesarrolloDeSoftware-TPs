﻿using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Services.Impl
{
    public interface ITicketDetalleService
    {
        Task<TicketDetalle> Create(TicketDetalleDtoIn newTicketDetalle);
        Task Delete(int id);
        Task<IEnumerable<TicketDetalle>> GetAll();
        Task<TicketDetalle?> GetById(int id);
        Task Update(int id, TicketDetalle TicketDetalle);
    }
}
using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Services;
using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Data.DTOs;

namespace ShopWebAPITP3.Controllers;
    [ApiController]
    [Route("[controller]")]

    public class TicketController : ControllerBase
    {
        private readonly TicketService _service;
        public TicketController(TicketService context)                  //Constructor
        {
            _service = context;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<Ticket>> Get()
        {
            return await _service.GetAll();
        }

        // GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var Ticket = await _service.GetById(id);

            if (Ticket == null)
            {
                return TicketNotFound(id);
            }
            return Ticket;
        }
        
        [HttpPost]
        public async Task<IActionResult>Create(TicketDto Ticket)
        {
            var newTicket = await _service.Create(Ticket);
            return CreatedAtAction(nameof(GetById),new {id = Ticket.IdTicket} ,newTicket);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TicketDto Ticket)
        {
            if (id != Ticket.IdTicket) return BadRequest(new { message= $"El ID ({id}) de la URL no coincide con el ID ({Ticket.IdTicket}) del cuerpo de la solicitud." });
            
            var TicketToUpdate = await _service.GetById(id);

            if (TicketToUpdate is not null)
            {
                await _service.Update(id,Ticket);
                return NoContent();
            }
            else
            {
                return TicketNotFound(id);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var TicketToDelete = await _service.GetById(id);

            if (TicketToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            else
            {
                return TicketNotFound(id);
            }
        }
        
        [NonAction]
        public NotFoundObjectResult TicketNotFound(int id)
        {
            return NotFound(new { message= $"El Ticket con ID = {id} no existe." });
        }
    }

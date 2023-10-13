using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Services;

namespace ShopWebAPITP3.Controllers;
[ApiController]
[Route("[controller]")]
public class TicketDetalleController : ControllerBase
{
    private readonly TicketDetalleService _service;
    public TicketDetalleController(TicketDetalleService ticketDetalle)                                               //Constructor
    {
        _service = ticketDetalle;
    }

    [HttpGet]
    public async Task<IEnumerable<TicketDetalle>> Get()
    {
        return await _service.GetAll();                                                 // Devuelve todos los ticketDetalles como una lista
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketDetalle>> GetById(int id)                                                // Los métodos dentro de un Controller se conocen como Actions
                                                                                                              // esto posibilita que pueda obtener disferentes métodos que proporciona
                                                                                                              // la clase ControllerBase 
    {
        var ticketDetalle = await _service.GetById(id);                                               // Cuando se haga el GET se pasa el id como parácmetro

        if (ticketDetalle is null)
            return TicketDetailNotFound(id);
        return ticketDetalle;
    }
    [HttpPost]
    public async Task<IActionResult> Create(TicketDetalleDtoIn ticketDetalle)
    {
        
        var newTicketDetalle = await _service.Create(ticketDetalle);                                                        // Se agrega el objeto en el contexto
        return CreatedAtAction(nameof(GetById), new { id = ticketDetalle.IdTicketDetalle }, newTicketDetalle);       //Enviamos la acción dentro de mi controlador que va a manejar ese proceso,
                                                                                                         //lamamos a GetById y el id que vamos a enviar para este método, va a ser el id que acabamos de crear
                                                                                                         //la información del objeto que va a ser el resultado que se le envía al resultado va a ser el objeto ticketDetalle 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TicketDetalle ticketDetalle)
    {
        if (id != ticketDetalle.IdTicketDetalle) return BadRequest(new { message = $"El ID ({id}) de la URL no coincide con el ID ({ticketDetalle.IdTicketDetalle}) del cuerpo de la solicitud." });

        var ticketDetailToUpdate = await _service.GetById(id);

        if (ticketDetailToUpdate is not null)
        {
            await _service.Update(id, ticketDetalle);
            return NoContent();
        }
        else
        {
            return TicketDetailNotFound(id);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ticketDetailToDelete = await _service.GetById(id);

        if (ticketDetailToDelete is not null)
        {
            await _service.Delete(id);
            return Ok();
        }
        else
        {
            return TicketDetailNotFound(id);
        }
    }
    [NonAction]
    public NotFoundObjectResult TicketDetailNotFound(int id)
    {
        return NotFound(new { message = $"El ticketDetalle con ID = {id} no existe." });
    }

}


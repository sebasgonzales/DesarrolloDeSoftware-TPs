using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Services;
using ShopWebAPITP3.Data.ShopModels;


namespace ShopWebAPITP3.Controllers;
    [ApiController]
    [Route("[controller]")]

    public class TarjetaController : ControllerBase
    {
        private readonly TarjetaService _service;
        public TarjetaController(TarjetaService context)                  //Constructor
        {
            _service = context;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<Tarjeta>> Get()
        {
            return await _service.GetAll();
        }

        // GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarjeta>> GetById(int id)
        {
            var Tarjeta = await _service.GetById(id);

            if (Tarjeta == null)
            {
                return TarjetaNotFound(id);
            }
            return Tarjeta;
        }
        
        [HttpPost]
        public async Task<IActionResult>Create(Tarjeta Tarjeta)
        {
            var newTarjeta = await _service.Create(Tarjeta);
            return CreatedAtAction(nameof(GetById),new {id = Tarjeta.IdTarjeta} ,newTarjeta);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Tarjeta Tarjeta)
        {
            if (id != Tarjeta.IdTarjeta) return BadRequest(new { message= $"El ID ({id}) de la URL no coincide con el ID ({Tarjeta.IdTarjeta}) del cuerpo de la solicitud." });
            
            var TarjetaToUpdate = await _service.GetById(id);

            if (TarjetaToUpdate is not null)
            {
                await _service.Update(id,Tarjeta);
                return NoContent();
            }
            else
            {
                return TarjetaNotFound(id);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var TarjetaToDelete = await _service.GetById(id);

            if (TarjetaToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            else
            {
                return TarjetaNotFound(id);
            }
        }
        
        [NonAction]
        public NotFoundObjectResult TarjetaNotFound(int id)
        {
            return NotFound(new { message= $"El Tarjeta con ID = {id} no existe." });
        }
    }

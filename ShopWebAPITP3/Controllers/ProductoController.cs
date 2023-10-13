using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Services;
using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Data.DTOs;

namespace ShopWebAPITP3.Controllers;
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;
        public ProductoController(ProductoService context)                  //Constructor
        {
            _service = context;
        }

        // GET
        [HttpGet]
        public async Task<IEnumerable<Producto>> Get()
        {
            return await _service.GetAll();
        }

        // GET By Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var producto = await _service.GetById(id);

            if (producto == null)
            {
                return ProductNotFound(id);
            }
            return producto;
        }
        
        [HttpPost]
        public async Task<IActionResult>Create(ProductoDtoIn producto)
        {
            var newProducto = await _service.Create(producto);
            return CreatedAtAction(nameof(GetById),new {id = producto.IdProducto} ,newProducto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductoDtoIn producto)
        {
            if (id != producto.IdProducto) return BadRequest(new { message= $"El ID ({id}) de la URL no coincide con el ID ({producto.IdProducto}) del cuerpo de la solicitud." });
            
            var productToUpdate = await _service.GetById(id);

            if (productToUpdate is not null)
            {
                await _service.Update(id,producto);
                return NoContent();
            }
            else
            {
                return ProductNotFound(id);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var productToDelete = await _service.GetById(id);

            if (productToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            else
            {
                return ProductNotFound(id);
            }
        }
        
        [NonAction]
        public NotFoundObjectResult ProductNotFound(int id)
        {
            return NotFound(new { message= $"El producto con ID = {id} no existe." });
        }
    }

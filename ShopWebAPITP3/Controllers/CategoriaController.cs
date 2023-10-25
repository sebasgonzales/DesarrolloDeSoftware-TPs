using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Data.DTOs;
using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Services;

namespace ShopWebAPITP3.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly CategoriaService _service;
    public CategoriaController(CategoriaService categoria)                                               //Constructor
    {
        _service = categoria;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoriaDtoOut>> Get()
    {
        return await _service.GetAll();                                                 // Devuelve todos los categorias como una lista
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Categoria>> GetById(int id)                                                // Los métodos dentro de un Controller se conocen como Actions
                                                                                                            // esto posibilita que pueda obtener disferentes métodos que proporciona
                                                                                                           // la clase ControllerBase 
    {
        var categoria = await _service.GetById(id);                                               // Cuando se haga el GET se pasa el id como parácmetro

        if (categoria is null)
            return CategoryNotFound(id);
        return categoria;
    }
    [HttpPost]
    public async Task<IActionResult> Create(CategoriaDtoIn categoria)
    {
        var newCategoria = await _service.Create(categoria);                                                        // Se agrega el objeto en el contexto
        return CreatedAtAction(nameof(GetById), new { id = categoria.IdCategoria }, newCategoria);       //Enviamos la acción dentro de mi controlador que va a manejar ese proceso,
                                                                                                   //lamamos a GetById y el id que vamos a enviar para este método, va a ser el id que acabamos de crear
                                                                                                   //la información del objeto que va a ser el resultado que se le envía al resultado va a ser el objeto categoria 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CategoriaDtoIn categoria)
    {
        if (id != categoria.IdCategoria) return BadRequest(new { message = $"El ID ({id}) de la URL no coincide con el ID ({categoria.IdCategoria}) del cuerpo de la solicitud." });

        var categoryToUpdate = await _service.GetById(id);

        if (categoryToUpdate is not null)
        {
            await _service.Update(id, categoria);
            return NoContent();
        }
        else
        {
            return CategoryNotFound(id);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var categoryToDelete = await _service.GetById(id);

        if (categoryToDelete is not null)
        {
            await _service.Delete(id);
            return Ok();
        }
        else
        {
            return CategoryNotFound(id);
        }
    }
    [NonAction]
    public NotFoundObjectResult CategoryNotFound(int id)
    {
        return NotFound(new { message = $"El categoria con ID = {id} no existe." });
    }

}


﻿using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Services;
using ShopWebAPITP3.Data.ShopModels;
using ShopWebAPITP3.Data.DTOs;

namespace ShopWebAPITP3.Controllers;
    [ApiController]
    [Route("[controller]")]

    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _service;
        public ClienteController(ClienteService cliente)                                               //Constructor
        {
            _service = cliente;
        }

        [HttpGet]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await  _service.GetAll();                                                 // Devuelve todos los clientes como una lista
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(int id)                                                // Los métodos dentro de un Controller se conocen como Actions
                                                                                                    // esto posibilita que pueda obtener disferentes métodos que proporciona
                                                                                                    // la clase ControllerBase 
        {
            var cliente = await _service.GetById(id);                                               // Cuando se haga el GET se pasa el id como parácmetro

            if (cliente is null)
                return ClientNotFound(id);
            return cliente;
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClienteDtoIn cliente)
        {
            var newCliente = await _service.Create(cliente);                                                        // Se agrega el objeto en el contexto
            return CreatedAtAction(nameof(GetById), new { id = cliente.IdCliente}, newCliente);       //Enviamos la acción dentro de mi controlador que va a manejar ese proceso,
                                                                                                   //lamamos a GetById y el id que vamos a enviar para este método, va a ser el id que acabamos de crear
                                                                                                   //la información del objeto que va a ser el resultado que se le envía al resultado va a ser el objeto cliente 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ClienteDtoIn cliente)
        {
            if (id != cliente.IdCliente) return BadRequest(new { message= $"El ID ({id}) de la URL no coincide con el ID ({cliente.IdCliente}) del cuerpo de la solicitud." });
            
            var clientToUpdate = await _service.GetById(id);

            if (clientToUpdate is not null)
            {
                await _service.Update(id,cliente);
                return NoContent();
            }
            else
            {
                return ClientNotFound(id);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clientToDelete = await _service.GetById(id);

            if (clientToDelete is not null)
            {
                await _service.Delete(id);
                return Ok();
            }
            else
            {
                return ClientNotFound(id);
            }
        }
        [NonAction]
        public NotFoundObjectResult ClientNotFound(int id)
        {
            return NotFound(new { message= $"El cliente con ID = {id} no existe." });
        }

    }


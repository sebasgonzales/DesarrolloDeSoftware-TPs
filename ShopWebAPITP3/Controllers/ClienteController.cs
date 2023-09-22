using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.ShopModels;


namespace ShopWebAPITP3.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ClienteController : ControllerBase
    {
        private readonly ShopContext _context;
        public ClienteController(ShopContext context)                                               //Constructor
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _context.Cliente.ToList();                                                       // Devuelve todos los clientes como una lista
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> GetById(int id)                                                // Los métodos dentro de un Controller se conocen como Actions
                                                                                                    // esto posibilita que pueda obtener disferentes métodos que proporciona
                                                                                                    // la clase ControllerBase 
        {
            var cliente = _context.Cliente.Find(id);                                                // Cuando se haga el GET se pasa el id como parácmetro

            if (cliente is null)
                return NotFound();
            return cliente;
        }
        [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            _context.Cliente.Add(cliente);                                                         // Se agrega el objeto en el contexto
            _context.SaveChanges();                                                                // Se agrega al objeto en la BD

            return CreatedAtAction(nameof(GetById), new { id = cliente.idCliente}, cliente);       //Enviamos la acción dentro de mi controlador que va a manejar ese proceso,
                                                                                                   //lamamos a GetById y el id que vamos a enviar para este método, va a ser el id que acabamos de crear
                                                                                                   //la información del objeto que va a ser el resultado que se le envía al resultado va a ser el objeto cliente 
        }

    }
}

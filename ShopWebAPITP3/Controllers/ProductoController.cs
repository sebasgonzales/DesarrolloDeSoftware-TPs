using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.ShopModels;


namespace ShopWebAPITP3.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController : ControllerBase
    {
        private readonly ShopContext _context;
        public ProductoController(ShopContext context)                  //Constructor
        {
            _context = context;
        }

        // GET
        public IEnumerable<Producto> Get()
        {
            return _context.Producto.ToList();
        }

        // GET By Id
        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _context.Producto.Find(id);

            if (producto == null)
            {
                return NotFound();
            }
            return (producto);
        }
        
        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            _context.Producto.Add(producto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById),new {id = producto.idProducto} ,producto);
        }
        /*
        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}

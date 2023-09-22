using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWebAPITP3.Data;
using ShopWebAPITP3.Data.ShopModels;

namespace ShopWebAPITP3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ShopContext _context;

        public TicketController(ShopContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return _context.Ticket;
        }

        //GET BY ID
        [HttpGet("{id}")]
        public ActionResult<Ticket> Get(int id)
        {
            var ticket = _context.Ticket.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        //POST
        [HttpPost]
        public IActionResult Post(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            _context.SaveChanges();

            return CreatedAtAction(nameof(ticket), new {id = ticket.idTicket} ,ticket);
        }
    }
}

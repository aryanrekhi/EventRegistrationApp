using Microsoft.AspNetCore.Mvc;
using EventRegistration.Data;
using EventRegistration.Models;
using System.Linq;

namespace EventRegistration.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clients = _context.Clients.ToList();
            return Ok(clients);
        }
    }
}

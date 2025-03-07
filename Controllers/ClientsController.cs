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
            var clients = _context.Clients
                .OrderByDescending(c => c.DateRegistered)
                .ToList();

            if (!clients.Any())
            {
                return Ok(new List<Client>()); // Return empty JSON array
            }

            return Ok(clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();
            return Ok(client);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] Client updatedClient)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();

            client.Name = updatedClient.Name;
            client.Email = updatedClient.Email;
            client.Gender = updatedClient.Gender;
            client.DateRegistered = updatedClient.DateRegistered;
            client.SelectedDays = updatedClient.SelectedDays;
            client.AdditionalRequest = updatedClient.AdditionalRequest;

            _context.SaveChanges();
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _context.Clients.Find(id);
            if (client == null) return NotFound();

            _context.Clients.Remove(client);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

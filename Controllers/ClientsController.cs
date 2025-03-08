using Microsoft.AspNetCore.Mvc;
using EventRegistration.Models;
using EventRegistration.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventRegistration.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly FirebaseService _firebaseService;

        public ClientsController(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var clients = await _firebaseService.GetClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetClient(string email)
        {
            string decodedEmail = Uri.UnescapeDataString(email.Trim().ToLower()); // ✅ Normalize and decode email

            var client = await _firebaseService.GetClientAsync(decodedEmail);
            if (client == null) return NotFound($"Client with email {decodedEmail} not found.");

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            string cleanEmail = client.Email.Trim().ToLower();
            client.Email = cleanEmail;  // ✅ Ensure consistent formatting before saving

            await _firebaseService.AddClientAsync(client);
            return CreatedAtAction(nameof(GetClients), new { email = client.Email }, client);
        }

        [HttpPut("{email}")]
        public async Task<IActionResult> UpdateClient(string email, [FromBody] Client client)
        {
            string decodedEmail = Uri.UnescapeDataString(email.Trim().ToLower()); // ✅ Decode email

            await _firebaseService.UpdateClientAsync(decodedEmail, client);
            return NoContent();
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteClient(string email)
        {
            string decodedEmail = Uri.UnescapeDataString(email.Trim().ToLower()); // ✅ Decode email

            await _firebaseService.DeleteClientAsync(decodedEmail);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistration.Models;
using EventRegistration.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventRegistration.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly FirebaseService _firebaseService;

        public IndexModel(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        public List<Client> Clients { get; set; } = new();

        public async Task OnGetAsync()
        {
            Clients = await _firebaseService.GetClientsAsync();
        }
    }
}

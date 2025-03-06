using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistration.Data;
using EventRegistration.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventRegistration.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Client> Clients { get; set; } = new();

        public void OnGet()
        {
            Clients = _context.Clients.OrderByDescending(c => c.DateRegistered).ToList();
        }
    }
}

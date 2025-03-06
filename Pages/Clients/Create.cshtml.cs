using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistration.Data;
using EventRegistration.Models;
using System.Linq;
using System.Collections.Generic;

namespace EventRegistration.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public Client Client { get; set; } = new();

        public List<string> SelectedDaysList { get; set; } = new();

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnPost()
        {
            Console.WriteLine("🚀 OnPost() method triggered!");

            // Manually capture checkbox values, ensuring non-null list
            SelectedDaysList = Request.Form["SelectedDaysList"].ToList() ?? new List<string>();

            if (SelectedDaysList.Count == 0)
            {
                Console.WriteLine("❌ No event days selected.");
                ViewData["DaysError"] = "At least one event day must be selected.";
                return Page();
            }

            // ✅ Check if the email already exists in the database
            bool emailExists = _context.Clients.Any(c => c.Email == Client.Email);
            if (emailExists)
            {
                Console.WriteLine($"❌ Duplicate email detected: {Client.Email}");
                ModelState.AddModelError("Client.Email", "This email is already registered.");
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ Model validation failed!");
                foreach (var error in ModelState)
                {
                    foreach (var err in error.Value.Errors)
                    {
                        Console.WriteLine($"❌ Validation Error: {error.Key} - {err.ErrorMessage}");
                    }
                }
                return Page();
            }

            // Convert list to a comma-separated string and save it in Client.SelectedDays
            Client.SelectedDays = string.Join(", ", SelectedDaysList);

            try
            {
                _context.Clients.Add(Client);
                _context.SaveChanges();
                Console.WriteLine("✅ Client successfully saved to database!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 Error saving client: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while saving. Please try again.");
                return Page();
            }

            return RedirectToPage("/Clients/Index");
        }
    }
}

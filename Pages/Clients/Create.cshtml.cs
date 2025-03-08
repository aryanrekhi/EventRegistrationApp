using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventRegistration.Models;
using EventRegistration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventRegistration.Pages.Clients
{
    public class CreateModel : PageModel
    {
        private readonly FirebaseService _firebaseService;

        [BindProperty]
        public Client Client { get; set; } = new();

        [BindProperty]
        public List<string> SelectedDaysList { get; set; } = new();

        public CreateModel(FirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("🚀 OnPost() method triggered!");

            // Capture checkbox values manually
            SelectedDaysList = Request.Form["SelectedDaysList"]
                .Select(d => d ?? string.Empty)
                .ToList();


            if (SelectedDaysList.Count == 0)
            {
                Console.WriteLine("❌ No event days selected.");
                ViewData["DaysError"] = "At least one event day must be selected.";
                return Page();
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ Model validation failed!");
                return Page();
            }

            Client.SelectedDays = string.Join(", ", SelectedDaysList);
            Client.DateRegistered = DateTime.UtcNow;  // ✅ Ensure UTC format


            try
            {
                await _firebaseService.AddClientAsync(Client);
                Console.WriteLine("✅ Client successfully saved to Firestore!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔥 Error saving client: {ex.Message}");
                ModelState.AddModelError(string.Empty, "An error occurred while saving. Please try again.");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}

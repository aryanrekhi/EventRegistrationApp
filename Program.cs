using EventRegistration.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Load Firebase Configuration
var firebaseConfigPath = builder.Configuration["Firebase:AuthFilePath"];
if (string.IsNullOrEmpty(firebaseConfigPath))
{
    throw new InvalidOperationException("Firebase configuration file is missing. Check appsettings.json.");
}

// Register Firebase Service
builder.Services.AddSingleton<FirebaseService>();
builder.Services.AddRazorPages();
builder.Services.AddControllers();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (!app.Environment.IsDevelopment()) 
{
    app.UseHttpsRedirection();  // ✅ HTTPS redirect only in production
}
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

// ✅ Ensure database is seeded on startup
using (var scope = app.Services.CreateScope())
{
    var firebaseService = scope.ServiceProvider.GetRequiredService<FirebaseService>();
    Console.WriteLine("🔄 Running database seeding...");
    await firebaseService.SeedDatabaseAsync();
    Console.WriteLine("✅ Seeding complete!");
}

app.Run();

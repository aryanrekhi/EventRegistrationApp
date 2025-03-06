using Microsoft.EntityFrameworkCore;
using EventRegistration.Models;
using System;

namespace EventRegistration.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = -1, // Negative ID to prevent conflicts
                    Name = "Alice Johnson",
                    Email = "alice@example.com",
                    Gender = 'F',
                    DateRegistered = new DateTime(2019, 1, 10),
                    SelectedDays = "Day 1, Day 3",
                    AdditionalRequest = "Vegetarian meal"
                },
                new Client
                {
                    Id = -2, // Negative ID
                    Name = "Bob Smith",
                    Email = "bob@example.com",
                    Gender = 'M',
                    DateRegistered = new DateTime(2019, 3, 15),
                    SelectedDays = "Day 2",
                    AdditionalRequest = "Need wheelchair access"
                },
                new Client
                {
                    Id = -3, // Negative ID
                    Name = "Charlie Brown",
                    Email = "charlie@example.com",
                    Gender = 'M',
                    DateRegistered = new DateTime(2019, 5, 25),
                    SelectedDays = "Day 1, Day 2",
                    AdditionalRequest = "No special request"
                }
            );
        }
    }
}

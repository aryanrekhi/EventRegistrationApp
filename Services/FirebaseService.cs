using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EventRegistration.Models;

namespace EventRegistration.Services
{
    public class FirebaseService
    {
        private readonly FirestoreDb _firestoreDb;

        public FirebaseService(IConfiguration configuration)
        {
            string projectId = configuration["Firebase:ProjectId"] ?? throw new Exception("Firebase ProjectId is missing in appsettings.json");
            string authFilePath = configuration["Firebase:AuthFilePath"] ?? throw new Exception("Firebase AuthFilePath is missing in appsettings.json");

            if (!File.Exists(authFilePath))
            {
                throw new FileNotFoundException($"Firebase configuration file not found at path: {authFilePath}");
            }

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", authFilePath);
            _firestoreDb = FirestoreDb.Create(projectId);
        }

        public async Task<List<Client>> GetClientsAsync()
        {
            List<Client> clients = new();
            QuerySnapshot snapshot = await _firestoreDb.Collection("clients").GetSnapshotAsync();
            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                if (doc.Exists)
                {
                    clients.Add(doc.ConvertTo<Client>());
                }
            }
            return clients;
        }

        public async Task<Client?> GetClientAsync(string email)
        {
            string cleanEmail = email.Trim().ToLower(); // ✅ Normalize email

            DocumentReference docRef = _firestoreDb.Collection("clients").Document(cleanEmail);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (!snapshot.Exists) return null;
            return snapshot.ConvertTo<Client>();
        }

        public async Task AddClientAsync(Client client)
        {
            string cleanEmail = client.Email.Trim().ToLower(); // ✅ Ensure Firestore stores lowercase email
            DocumentReference docRef = _firestoreDb.Collection("clients").Document(cleanEmail);
            await docRef.SetAsync(client);
        }

        public async Task UpdateClientAsync(string email, Client client)
        {
            string cleanEmail = email.Trim().ToLower(); // ✅ Normalize email
            DocumentReference docRef = _firestoreDb.Collection("clients").Document(cleanEmail);
            await docRef.SetAsync(client, SetOptions.MergeAll);
        }

        public async Task DeleteClientAsync(string email)
        {
            string cleanEmail = email.Trim().ToLower(); // ✅ Normalize email
            DocumentReference docRef = _firestoreDb.Collection("clients").Document(cleanEmail);
            await docRef.DeleteAsync();
        }

        // ✅ Auto-seed database with 3 default clients on startup
        public async Task SeedDatabaseAsync()
        {
            Console.WriteLine("🌱 Seeding database with default clients...");

            List<Client> defaultClients = new()
            {
                new Client { Name = "Alice Johnson", Email = "alice@example.com", Gender = "F", DateRegistered = new DateTime(2019, 01, 10, 0, 0, 0, DateTimeKind.Utc), SelectedDays = "Day 1, Day 3", AdditionalRequest = "Vegetarian meal" },
                new Client { Name = "Bob Smith", Email = "bob@example.com", Gender = "M", DateRegistered = new DateTime(2019, 03, 15, 0, 0, 0, DateTimeKind.Utc), SelectedDays = "Day 2", AdditionalRequest = "Need wheelchair access" },
                new Client { Name = "Charlie Brown", Email = "charlie@example.com", Gender = "M", DateRegistered = new DateTime(2019, 05, 25, 0, 0, 0, DateTimeKind.Utc), SelectedDays = "Day 1, Day 2", AdditionalRequest = "No special request" }
            };

            foreach (var client in defaultClients)
            {
                await AddClientAsync(client);
                Console.WriteLine($"✅ Seeded: {client.Name} ({client.Email})");
            }

            Console.WriteLine("✅ Database seeding complete!");
        }
    }
}

# 🎟️ Event Registration App

A **ASP.NET Core Razor Pages** application for registering and managing event attendees efficiently.

## 🚀 Features
- ✅ **Register new clients**
- ✅ **Select event days (checkbox binding fixed)**
- ✅ **Prevent duplicate email registrations**
- ✅ **Display all registered clients dynamically**
- ✅ **Sort clients by latest registration**
- ✅ **Database: SQL Server LocalDB**
- ✅ **Web API for fetching clients (`/api/clients`)**

---

## 📌 Getting Started

### **1️⃣ Clone the Repository**
```sh
git clone https://github.com/aryanrekhi/EventRegistrationApp.git
cd EventRegistrationApp
2️⃣ Setup the Database
Apply the latest database migrations:

sh
Copy
Edit
dotnet ef database update
3️⃣ Run the Application
sh
Copy
Edit
dotnet run
4️⃣ Open in Browser
Register a new client:
🔗 http://localhost:5168/Clients/Create

View all registered clients:
🔗 http://localhost:5168/Clients/Index

Fetch client data via API (JSON output):
🔗 http://localhost:5168/api/clients

🔹 Database Setup
This app uses SQL Server LocalDB for storage.

If you need to reset the database, run:

sh
Copy
Edit
dotnet ef database drop --force
dotnet ef database update
🔹 Web API for Clients
The application exposes a Web API endpoint to fetch client data dynamically.

GET Clients List

http
Copy
Edit
GET /api/clients
Example Response (JSON)

json
Copy
Edit
[
  {
    "id": 1,
    "name": "Alice Johnson",
    "email": "alice@example.com",
    "gender": "F",
    "dateRegistered": "2019-01-10T00:00:00",
    "selectedDays": "Day 1, Day 3",
    "additionalRequest": "Vegetarian meal"
  }
]
🛠️ Technologies Used
ASP.NET Core Razor Pages
Entity Framework Core
SQL Server LocalDB
JavaScript (for dynamic client list loading)
Bootstrap (for styling - optional)
🎯 Author
👨‍💻 Developed by Aryan Rekhi
🔗 GitHub: github.com/aryanrekhi

📌 Adding README to GitHub
Option 1: Using GitHub UI
Go to your repository:
🔗 https://github.com/aryanrekhi/EventRegistrationApp
Click "Add a README".
Paste this content into the editor.
Click "Commit changes".
Option 2: Using Git
Create a README.md file locally:
sh
Copy
Edit
echo "# Event Registration App" >> README.md
Open README.md in VS Code or Notepad, paste the content, and save.
Commit & Push:
sh
Copy
Edit
git add README.md
git commit -m "Added README.md with project setup instructions"
git push origin main

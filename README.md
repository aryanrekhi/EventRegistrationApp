# 🎟️ Event Registration App

A modern **ASP.NET Core Razor Pages** application for registering and managing event attendees.

## 🚀 Features
- ✅ **Register new clients with real-time validation**
- ✅ **Dark Mode & Light Mode Toggle**
- ✅ **Fully responsive & beautiful UI**
- ✅ **Select event days (checkbox binding fixed)**
- ✅ **Prevent duplicate email registrations**
- ✅ **Edit & Delete Clients with Instant UI Updates**
- ✅ **Real-Time Search & Filtering**
- ✅ **Download Clients as CSV**
- ✅ **Uses SQL Server LocalDB for database storage**
- ✅ **Web API for fetching clients (`/api/clients`)**

---

## 📌 Setup Instructions

### **1️⃣ Install .NET 9.0 SDK** (if not installed)
Before running the application, ensure you have .NET 9.0 installed.  
Download and install it from: [Download .NET 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)

To check if .NET is installed, run:
```sh
dotnet --version
```
Ensure it outputs a version starting with `9.0`.

---

### **2️⃣ Clone the Repository**
To download the project, run:
```sh
git clone https://github.com/aryanrekhi/EventRegistrationApp.git
cd EventRegistrationApp
```

---

### **3️⃣ Setup the Database**
Apply database migrations:
```sh
dotnet ef database update
```

---

### **4️⃣ Run the Application**
```sh
dotnet run
```

---

### **5️⃣ Open in Browser**
Register a new client:
```
http://localhost:5168/Clients/Create
```

View all registered clients:
```
http://localhost:5168/Clients/Index
```

Fetch client data via API (JSON output):
```
http://localhost:5168/api/clients
```

---

## 🔹 Database Setup
The app uses **SQL Server LocalDB**.  
If you need to reset the database, run:
```sh
dotnet ef database drop --force
dotnet ef database update
```

---

## 🔹 Web API for Clients
This application exposes a Web API for fetching client data dynamically.

**GET Clients List:**
```
GET /api/clients
```

**GET Single Client by ID:**
```
GET /api/clients/{id}
```

**DELETE a Client:**
```
DELETE /api/clients/{id}
```

**UPDATE a Client:**
```
PUT /api/clients/{id}
```

Example Response (JSON):
```json
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
```

---

## 🛠️ Technologies Used
✔ **ASP.NET Core Razor Pages**  
✔ **Entity Framework Core**  
✔ **SQL Server LocalDB**  
✔ **JavaScript (for live search, edit & delete)**  
✔ **Bootstrap & TailwindCSS for modern UI**  
✔ **Font Awesome for icons**  

---

## 🎯 Author
👨‍💻 Developed by **Aryan Rekhi**  
🔗 GitHub: [@aryanrekhi](https://github.com/aryanrekhi)

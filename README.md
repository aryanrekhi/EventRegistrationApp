# 🎟️ Event Registration App

A modern **ASP.NET Core Razor Pages** application for registering and managing event attendees.

---

## 🚀 Features
✅ **Built with .NET 9.0 & ASP.NET Core Razor Pages**  
✅ **Register new clients with real-time validation**  
✅ **Dark Mode & Light Mode Toggle**  
✅ **Fully responsive & modern UI**  
✅ **Select event days (checkbox binding fixed)**  
✅ **Prevent duplicate email registrations**  
✅ **Edit & Delete Clients with Instant UI Updates**  
✅ **Real-Time Search & Filtering**  
✅ **Download Clients as CSV**  
✅ **Uses SQL Server LocalDB for database storage**  
✅ **Web API for fetching clients (`/api/clients`)**  

---

## 📌 Setup Instructions

### **1️⃣ Clone the Repository**
Run the following command:
```sh
git clone https://github.com/aryanrekhi/EventRegistrationApp.git
cd EventRegistrationApp
```

### **2️⃣ Setup the Database**
Apply database migrations:
```sh
dotnet ef database update
```

### **3️⃣ Run the Application**
```sh
dotnet run
```

### **4️⃣ Open in Browser**
- **Register a new client:** [http://localhost:5168/Clients/Create](http://localhost:5168/Clients/Create)  
- **View all registered clients:** [http://localhost:5168/Clients/Index](http://localhost:5168/Clients/Index)  
- **Fetch client data via API (JSON output):** [http://localhost:5168/api/clients](http://localhost:5168/api/clients)  

---

## 🔹 **Database Setup**
The app uses **SQL Server LocalDB**. If you need to reset the database, run:
```sh
dotnet ef database drop --force
dotnet ef database update
```

---

## 🔹 **Web API for Clients**
This application exposes a Web API for dynamically fetching client data.

### **GET Clients List**
```http
GET /api/clients
```

### **GET Single Client by ID**
```http
GET /api/clients/{id}
```

### **DELETE a Client**
```http
DELETE /api/clients/{id}
```

### **UPDATE a Client**
```http
PUT /api/clients/{id}
```

### **Example Response (JSON)**
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

## 🛠️ **Technologies Used**
✔ **.NET 9.0** & **ASP.NET Core Razor Pages**  
✔ **Entity Framework Core**  
✔ **SQL Server LocalDB**  
✔ **JavaScript** (for live search, edit & delete)  
✔ **Bootstrap & TailwindCSS** (modern UI)  
✔ **Font Awesome** (icons)  

---

## 🎯 **Author**
👨‍💻 Developed by **Aryan Rekhi**  
🔗 **GitHub:** [https://github.com/aryanrekhi](https://github.com/aryanrekhi)  

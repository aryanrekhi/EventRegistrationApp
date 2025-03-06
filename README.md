# 🎟️ Event Registration App

A **ASP.NET Core Razor Pages** application for registering and managing event attendees.

## 🚀 Features
- ✅ **Register new clients**
- ✅ **Select event days (checkbox binding fixed)**
- ✅ **Prevent duplicate email registrations**
- ✅ **Display all registered clients dynamically**
- ✅ **Sort clients by latest registration**
- ✅ **Database: SQL Server LocalDB**
- ✅ **Web API for fetching clients (`/api/clients`)**

---

## 📌 Setup Instructions
### **1️⃣ Clone the Repository**
To download the project, run:
```sh
git clone https://github.com/aryanrekhi/EventRegistrationApp.git
```
```sh
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
- **Register a new client:**  
  ```
  http://localhost:5168/Clients/Create
  ```
- **View all registered clients:**  
  ```
  http://localhost:5168/Clients/Index
  ```
- **Fetch client data via API (JSON output):**  
  ```
  http://localhost:5168/api/clients
  ```

---

## 🔹 Database Setup
- The app uses **SQL Server LocalDB**.
- If you need to reset the database, run:
  ```sh
  dotnet ef database drop --force
  dotnet ef database update
  ```

---

## 🔹 Web API for Clients
This application exposes a **Web API** for fetching client data dynamically.

- **GET Clients List**:
  ```
  GET /api/clients
  ```
- **Example Response (JSON)**:
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
✔ **JavaScript (for loading client list dynamically)**  
✔ **Bootstrap (for styling - optional)**  

---

## 🎯 Author
👨‍💻 Developed by **Aryan Rekhi**  
🔗 GitHub: [https://github.com/aryanrekhi](https://github.com/aryanrekhi)

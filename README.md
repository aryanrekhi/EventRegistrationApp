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
- ✅ **Uses Firebase Firestore for cloud database storage**
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

### **3️⃣ Setup Firebase Firestore Database**
Since this project **originally used SQL Server LocalDB** but was later **migrated to Firebase Firestore**, follow these steps:

#### **📌 Step 1: Create a Firebase Project**
1. **Go to Firebase Console** → [https://console.firebase.google.com/](https://console.firebase.google.com/)
2. **Click "Create a Project"** → Name it **EventRegistrationApp**.
3. **Click "Continue"** and disable Google Analytics.
4. **Click "Create"** → Wait for Firebase to set up.

#### **📌 Step 2: Enable Firestore Database**
1. **Go to Firestore Database** in Firebase.
2. **Click "Create Database"** → Select **Start in Test Mode**.
3. **Click "Next"** and set the location.

#### **📌 Step 3: Download Firebase Credentials**
1. **Go to Firebase Console** → Click **Project Settings**.
2. **Go to the "Service Accounts" tab**.
3. **Click "Generate New Private Key"**.
4. **Download the JSON file**.
5. **Move it to your project folder and note the exact path** (e.g., `C:\Users\YourName\EventRegistration\firebase-config.json`).

#### **📌 Step 4: Configure Firebase Credentials**
1. **Modify `appsettings.json`** and update the Firebase authentication path:

```json
{
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*",
    "Firebase": {
        "ProjectId": "your-firebase-project-id",
        "AuthFilePath": "C:\\Users\\YourName\\EventRegistration\\firebase-config.json"
    }
}
```
> **Important:** Replace `C:\\Users\\YourName\\EventRegistration\\firebase-config.json` with your **own** correct file path!

2. **Remove `firebase-config.json` from `.gitignore`** to ensure it's available when running the application.

---

### **4️⃣ Build & Run the Application**
Before running the app, clean and build the project to avoid issues:

```sh
dotnet clean
dotnet build
dotnet run
```

---

### **5️⃣ Open in Browser**
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

## 🔹 Web API for Clients
This application exposes a **Web API** for fetching client data dynamically.

**GET Clients List:**
```
GET /api/clients
```

**GET Single Client by Email:**
```
GET /api/clients/{email}
```

**DELETE a Client:**
```
DELETE /api/clients/{email}
```

**UPDATE a Client:**
```
PUT /api/clients/{email}
```

**Example Response (JSON):**
```json
[
  {
    "name": "Alice Johnson",
    "email": "alice@example.com",
    "gender": "F",
    "dateRegistered": "2019-01-10T00:00:00Z",
    "selectedDays": "Day 1, Day 3",
    "additionalRequest": "Vegetarian meal"
  }
]
```

---

## 🛠️ Technologies Used
✔ **ASP.NET Core Razor Pages**  
✔ **Firebase Firestore (Cloud Database)**  
✔ **Google Cloud Firestore SDK**  
✔ **JavaScript (for live search, edit & delete)**  
✔ **Bootstrap & TailwindCSS for modern UI**  
✔ **Font Awesome for icons**  

---

## 🎯 Notes on Database Migration
- Initially, this project was **built using SQL LocalDB** as per the assignment.
- Later, we **migrated the database to Firebase Firestore** for:
  - **Better scalability**
  - **Easier setup (No need for migrations)**
  - **Cloud storage instead of local storage**

---

## 🎯 Author
👨‍💻 Developed by **Aryan Rekhi**  
🔗 GitHub: [@aryanrekhi](https://github.com/aryanrekhi)

---

> **⚠ Need Firebase credentials?** Request them from the author or set up a new Firebase project using the steps above.

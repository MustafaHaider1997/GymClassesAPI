# Gym Classes API

Gym Classes API is a **.NET Core Web API** that allows gym owners and members to manage **classes, bookings, and search bookings**.  
It provides a simple **RESTful API** for handling gym-related operations **without requiring a database**.  

---

## **✨ Features**
- ✅ **Create a Gym Class** with **name, schedule, duration, and capacity**.
- ✅ **Book a Class** for a **specific date** while ensuring **capacity constraints**.
- ✅ **Search Bookings** **by member name, date range, or both**.
- ✅ **In-Memory Storage** (No database setup required).
- ✅ **Unit Tested** with `xUnit`.

---

## **🛠 Tech Stack**
- **C#** (.NET Core 8 Web API)
- **ASP.NET Core**
- **RESTful API Design**
- **Dependency Injection**
- **In-Memory Storage (No Database)**
- **Unit Testing (xUnit)**

---

## **📂 Project Structure**
```
GymClassesAPI/
│-- Controllers/         # API Controllers
│   ├── ClassController.cs
│   ├── BookingController.cs
│-- Models/              # Data Models
│   ├── ClassModel.cs
│   ├── BookingModel.cs
│-- Repositories/        # In-Memory Repositories
│   ├── ClassRepository.cs
│   ├── BookingRepository.cs
│-- Tests/               # Unit Tests
│   ├── ClassControllerTests.cs
│   ├── BookingControllerTests.cs
├── README.md            # Documentation
├── GymClassesAPI.sln    # Solution File
└── .gitignore           # Git Ignore File
```

---

## **🚀 How to Run the API Locally**
### **1️⃣ Clone the Repository**
```sh
git clone https://github.com/MustafaHaider1997/GymClassesAPI.git
cd GymClassesAPI
```

### **2️⃣ Install Dependencies**
```sh
dotnet restore
```

### **3️⃣ Run the API**
```sh
dotnet run
```
✅ **API will start on:** `https://localhost:<port>/swagger/index.html`  
✅ Open **Swagger UI** or **Postman** to test API endpoints.

---

## **🔍 API Endpoints**
### **1️⃣ Create a Class**
- **Endpoint:** `POST /api/classes`
- **Request Body:**
```json
{
  "name": "Pilates",
  "startDate": "2025-02-01",
  "endDate": "2025-02-10",
  "startTime": "14:00:00",
  "duration": 60,
  "capacity": 5
}
```
- **Response:** `201 Created`

---

### **2️⃣ Book a Class**
- **Endpoint:** `POST /api/bookings`
- **Request Body:**
```json
{
  "memberName": "John Doe",
  "classId": "<PASTE CLASS ID>",
  "participationDate": "2025-02-02"
}
```
- **Response:** `201 Created`

---

### **3️⃣ Search Bookings**
#### ✅ **Search by Member Name**
- **Endpoint:** `GET /api/bookings?memberName=John Doe`
- **Response:** List of John Doe’s bookings.

#### ✅ **Search by Date Range**
- **Endpoint:** `GET /api/bookings?startDate=2025-02-01&endDate=2025-02-05`
- **Response:** All bookings within the date range.

#### ✅ **Search by Member Name + Date Range**
- **Endpoint:** `GET /api/bookings?memberName=John Doe&startDate=2025-02-01&endDate=2025-02-05`
- **Response:** John Doe’s bookings within the date range.

---

## **🧪 Run Unit Tests**
- The project includes **xUnit** tests to verify API functionality.

### **1️⃣ Run All Tests**
```sh
dotnet test
```
### **2️⃣ Expected Output**
✅ **All tests should pass.**

---

## **📌 Future Enhancements**
🔹 **Use SQL Database (EF Core) for data persistence**  
🔹 **Implement Authentication (JWT, OAuth)**  
🔹 **Add Admin Role for Class Management**  
🔹 **Improve Booking Cancellation Features**  

---

## **📜 License**
This project is **MIT Licensed**. You are free to use and modify it.

---

## **🌟 Contributors**
👤 **Syed Mustafa Haider** – _Lead Developer_  
📧 [mustafahaider12@hotmail.com](mailto:mustafahaider12@hotmail.com)

---

### **🔗 Useful Links**
- 📜 **GitHub Repo:** [GymClassesAPI](https://github.com/MustafaHaider1997/GymClassesAPI)
- 📖 **.NET Core Documentation:** [ASP.NET Core Guide](https://learn.microsoft.com/en-us/aspnet/core/)
- 🧪 **xUnit Testing:** [xUnit Documentation](https://xunit.net/)
```

---

### **✅ Final Steps**
1. **Add the README.md to GitHub**
```sh
git add README.md
git commit -m "Added README.md"
git push origin main
```

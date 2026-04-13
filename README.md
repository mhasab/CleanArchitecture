# 🚀 Clean Architecture .NET API — Production-Oriented Backend

A **production-oriented backend project** built with ASP.NET Core following **Clean Architecture principles**, designed for scalability, maintainability, and real-world enterprise use cases.

> 💡 This project demonstrates how to structure a modern backend using CQRS, Repository Pattern, and layered architecture.

---

## 🧩 Key Features

* 🏗️ Clean Architecture (Domain, Application, Infrastructure, API)
* ⚡ CQRS with MediatR
* 🔄 Generic Repository Pattern
* 🧱 Unit of Work Pattern
* 🗄️ Entity Framework Core (DbContext)
* 🔁 AutoMapper (Entity ↔ DTO mapping)
* 🌐 RESTful API Design
* 📄 Swagger (API documentation)
* 🔐 CORS Configuration
* 🔒 Authentication & Authorization (JWT, Roles, Policies)
* 🚀 Live Deployment

---

## 🏛️ Architecture Design

This project strictly follows **Separation of Concerns**:

* **Domain Layer** → Core business logic & interfaces
* **Application Layer** → Use cases (CQRS, Handlers, DTOs)
* **Infrastructure Layer** → Database access (EF Core, Repositories)
* **API Layer** → Controllers, Middleware, Configuration

---

## 🔄 Request Lifecycle

```text
Client → Controller → MediatR → Handler → UnitOfWork → Repository → DbContext → Database
```

---

## 🧠 Technical Highlights

### ✔ CQRS + MediatR

* Clear separation between **Read (Queries)** and **Write (Commands)**
* Loose coupling between layers

---

### ✔ Repository + Unit of Work

* Centralized data access
* Transaction-friendly structure
* Easily extendable

---

### ✔ EF Core Integration

* DbContext-based data handling
* Async operations for performance

---

### ✔ AutoMapper

* Clean separation between domain models and DTOs

---

## 🔐 Authorization & Authentication (Advanced)

* 🔑 JWT Authentication (Access Token & Refresh Token)
* 👤 Role-Based Authorization (Admin / User / etc.)
* 🛡️ Policy-Based Authorization (Fine-grained access control)
* 🔒 Secure Endpoints using `[Authorize]` attributes
* 🔄 Token Validation & Expiration Handling
* 🚫 Protected Routes & Restricted Access
* 🧩 Scalable Identity Integration (ASP.NET Core Identity ready)

---

## 🧠 Security Highlights

### ✔ JWT Authentication

* Stateless and scalable authentication mechanism
* Secure API access using bearer tokens
* Supports refresh tokens for extended sessions

---

## 🌐 Live Demo

🔗 API Base URL:  
http://cleanarchitecture.tryasp.net  

🔗 Swagger UI:  
http://cleanarchitecture.tryasp.net/swagger  

---

## 📂 Project Structure

```text
src/
 ├── Domain/
 ├── Application/
 ├── Infrastructure/
 └── API/
```

---

## ⚙️ Run Locally

```bash
git clone https://github.com/mhasab/CleanArchitecture.git
cd CleanArchitecture
dotnet run --project src/API
```

---

## 🧪 Example Endpoints

```http
GET /api/users
GET /api/users/{id}
POST /api/user/create
```

---

## 🔐 Security (In Progress)

* Role-Based Authorization (implemented / improving)
* Refresh Tokens (planned)

---

## 📈 Future Improvements

* 🔐 Advanced JWT & Refresh Token Strategy
* ✅ FluentValidation (Validation Pipeline)
* ⚠️ Global Exception Handling Middleware
* 📊 Logging (Serilog)
* 📄 Pagination & Filtering
* ⚡ Caching (Redis)

---

## 🎯 Why This Project?

This project reflects:

* Strong understanding of **Clean Architecture**
* Practical implementation of **CQRS & MediatR**
* Secure API design with **Authentication & Authorization**
* Ability to build **scalable backend systems**
* Writing **maintainable and testable code**

---

## 👨‍💻 Author

**Mohamed Shaban**

* Backend Developer (.NET)
* Focused on scalable architectures & real-world systems

---

## ⭐ Support

If you like this project, give it a ⭐ on GitHub — it helps a lot!

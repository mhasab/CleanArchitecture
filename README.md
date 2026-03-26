# Clean Architecture (.NET) - In Progress 🚧

This project is a **learning-driven implementation of Clean Architecture** using ASP.NET Core.

The goal is to gradually build a scalable backend by applying modern design patterns step by step.

---

## 🚀 Current Progress

So far, the project includes:

* ✅ Clean Architecture structure
* ✅ CQRS (Command Query Responsibility Segregation)
* ✅ MediatR (for handling requests & decoupling)
* ✅ AutoMapper (for mapping between models & DTOs)
* ✅ Static Data Source (no database yet)

> ⚠️ Note: The project is still under development and will be expanded over time.

---

## 🏗️ Architecture Overview

The solution is organized into layers following Clean Architecture principles:

### 🔹 Domain Layer

* Core entities
* Business rules (basic)

---

### 🔹 Application Layer

* CQRS (Commands & Queries)
* MediatR handlers
* DTOs
* AutoMapper profiles

---

### 🔹 API Layer

* Controllers
* Request handling via MediatR

---

## 🧠 Implemented Concepts

### 1. CQRS + MediatR

Example Query:

```csharp id="c1a9x2"
public record GetUserById(int Id) : IRequest<UserDto>;
```

Handler:

```csharp id="v4p8lm"
public class GetUserByIdHandler : IRequestHandler<GetUserById, UserDto>
{
    public async Task<UserDto> Handle(GetUserById request, CancellationToken cancellationToken)
    {
        // Currently uses static data
    }
}
```

---

### 2. AutoMapper

Used to map between models and DTOs:

```csharp id="m92kfd"
CreateMap<User, UserDto>();
```

---

## 📂 Project Structure

```bash id="y3f9lw"
src/
 ├── Domain/
 │    ├── Entities/
 │    └── Interfaces/
 │
 ├── Application/
 │    ├── Features/
 │    │    └── Users/
 │    │         ├── Commands/
 │    │         ├── Queries/
 │    │         ├── Handlers/
 │    │         └── Mapping/
 │    └── DTOs/
 │
 ├── Infrastructure/
 │    └── Repositories/
 │
 └── API/
      ├── Controllers/
      └── Program.cs
```

---

## ⚙️ Running the Project

```bash id="k3p9zx"
git clone https://github.com/mhasab/CleanArchitecture.git
cd CleanArchitecture
dotnet run --project src/API
```

---

## 🔄 Current Flow

1. API receives request
2. Controller sends request via MediatR
3. Handler processes request
4. Static data is returned
5. AutoMapper maps response → DTO

---

## 🧪 Next Steps (Planned)

The project will be extended to include:

* ⏳ Database integration (EF Core)
* ⏳ Repository Pattern
* ⏳ Validation Pipeline
* ⏳ FluentValidation
* ⏳ Authentication & Authorization (JWT)
* ⏳ Exception Handling Middleware
* ⏳ Logging

---

## 🎯 Purpose

This project is meant to:

* Practice Clean Architecture in a real scenario
* Understand CQRS & MediatR deeply
* Build a reusable backend structure

---

## 🤝 Contributing

Feel free to fork or follow along as the project evolves.

---

## ⭐ Support

If you find this helpful, consider giving it a ⭐

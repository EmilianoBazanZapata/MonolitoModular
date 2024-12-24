
# TaskManagerSystem

**TaskManagerSystem** is a modular monolith application built with **ASP.NET Core 8** using Clean Architecture principles. It provides functionality to manage tasks, projects, and users, with integrated authentication and role-based authorization.

---

## Features

- **Projects Management**
  - Create, update, delete, and retrieve projects.
  - Validation for unique project names and date constraints.
  
- **Tasks Management**
  - Assign tasks to users.
  - Validate task deadlines and user assignments.
  - Modular design for handling domain-specific logic.
  
- **Users Management**
  - Authentication using **Identity** with JWT.
  - Role-based authorization (Admin, Usuario).
  - Auto-assign default roles during user creation.
  
- **Shared Services**
  - Unified controllers for modular API endpoints.
  - Reusable services and validators.

---

## Architecture

The application is designed as a **modular monolith** with the following modules:

- **Modules**
  - `Tasks`: Handles all task-related logic and operations.
  - `Projects`: Manages projects and their associations.
  - `Users`: Authentication, authorization, and user management.

- **Shared Layer**
  - Contains shared logic such as base entities, helpers, and reusable components.
  
- **Clean Architecture**
  - Core (Entities, Interfaces, Validators)
  - Application (CQRS commands, queries, and mediators)
  - Infrastructure (Database context, repositories)
  - API (Controllers and middleware)

---

## Roadmap

- [x] Modularize the application by separating core modules.
- [x] Implement CQRS with MediatR for projects, tasks, and users.
- [x] Authentication and role-based authorization with Identity.
- [x] Integrate shared logic into a dedicated `Shared` layer.
- [x] Seed data for roles and default admin user.
- [x] Swagger integration for API documentation and testing.

---

## Setup Instructions

### Prerequisites

- [.NET Core 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- Docker (optional for containerized databases)

### Configuration

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd TaskManagerSystem
   ```

2. **Set up database connections**:
   Update the `appsettings.json` file with your PostgreSQL connection string:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=TaskManagerDB;Username=your_user;Password=your_password"
      },
      "Jwt": {
        "Key": "your_secret_key",
        "Issuer": "your_issuer",
        "Audience": "your_audience"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Debug",
          "Microsoft.AspNetCore": "Debug"
        }
      },
      "AllowedHosts": "*"
    }
    ```

3. **Run database migrations**:
   ```bash
   dotnet ef database update
   ```

4. **Seed initial data**:
   The roles and default admin user will be seeded automatically during application startup.

### Running the Application

1. Run the application:
   ```bash
   dotnet run --project TaskManagerSystem.Api
   ```

2. Access the API:
   - Swagger: [http://localhost:5223/swagger](http://localhost:5223/swagger)

---

### Postman Collection

Import the provided Postman collection (`postman_collection.json`) to test the API endpoints.

---

## Contributing

Feel free to submit issues and pull requests. Ensure proper testing before proposing changes.

---

## Acknowledgments

Built with love and attention to detail using the latest ASP.NET Core features.

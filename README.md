
# TaskManagerSystem

A robust and modular task management system built with **ASP.NET Core 8**, designed with clean architecture principles. It supports project and task tracking, user role management, and JWT-based authentication.

## Features

- **Modular Design**: Implements clean architecture for scalability and maintainability.
- **Task Management**: CRUD operations for tasks and projects.
- **User Management**: Role-based user authentication and authorization.
- **JWT Authentication**: Secure token-based authentication.
- **Database Integration**: Supports PostgreSQL for relational data storage.
- **Swagger UI**: API documentation and testing interface.
- **Middleware**: Centralized error handling and response management.

---

## Prerequisites

- [.NET Core 8 SDK](https://dotnet.microsoft.com/)
- [PostgreSQL](https://www.postgresql.org/)
- A tool for API testing (e.g., [Postman](https://www.postman.com/))
- [Docker](https://www.docker.com/) (optional, for containerized database setup)

---

## Getting Started

### 1. Clone the Repository

```bash
git clone <repository_url>
cd TaskManagerSystem
```

### 2. Set Up the Environment Variables

Create an `appsettings.json` file in the `TaskManagerSystem.Api` project with the following structure:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_PostgreSQL_Connection_String",
    "IdentityConnection": "Your_PostgreSQL_Connection_String_For_Identity"
  },
  "Jwt": {
    "Key": "YourSecureKey1234567890",
    "Issuer": "TaskManagerSystem",
    "Audience": "TaskManagerUsers"
  }
}
```

---

### 3. Database Setup

#### Option 1: Manual Setup
- Create two PostgreSQL databases:
  - **TaskManagerSystem**
  - **TaskManagerIdentity**

#### Option 2: Docker
Run the following Docker command for PostgreSQL:

```bash
docker run --name taskmanager-postgres -e POSTGRES_USER=YourUsername -e POSTGRES_PASSWORD=YourPassword -p 5432:5432 -d postgres
```

---

### 4. Run Database Migrations

Navigate to the `TaskManagerSystem.Api` folder and execute:

```bash
dotnet ef database update --context AppDbContext
dotnet ef database update --context AppIdentityDbContext
```

---

### 5. Run the Application

Start the application using:

```bash
dotnet run --project TaskManagerSystem.Api
```

Access the Swagger UI at: `http://localhost:5029/swagger`

---

## Testing

- Use **Postman** or **Swagger UI** to test API endpoints.
- Authenticate via the `/api/auth/login` endpoint to retrieve a JWT token.
- Include the token in the `Authorization` header for protected routes.

---

## Folder Structure

```plaintext
TaskManagerSystem/
│
├── TaskManagerSystem.Api/
│   ├── Controllers/
│   ├── Helpers/
│   ├── Middlewares/
│   └── Program.cs
│
├── TaskManagerSystem.Application/
│   ├── DTOs/
│   ├── Services/
│   ├── Mappings/
│   └── Validations/
│
├── TaskManagerSystem.Core/
│   ├── Entities/
│   ├── Interfaces/
│   ├── Enums/
│   └── Specifications/
│
├── TaskManagerSystem.Infrastructure/
│   ├── Data/
│   ├── Repositories/
│   ├── Configurations/
│   └── Identity/
│
└── TaskManagerSystem.sln
```

---

## Roadmap

- [x] Implement task and project management.
- [x] Add user authentication and role-based authorization.
- [x] Integrate JWT authentication.
- [ ] **Add email notifications for task updates** *(In Progress)*.
- [ ] **Create a user-friendly front-end interface** *(In Progress)*.

---

## Contributing

Contributions are welcome! Please fork this repository and submit a pull request for review.

---

## License

This project is licensed under the [MIT License](LICENSE).

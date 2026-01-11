# Modern Stack Lab

A full-stack development sandbox exploring modern web technologies. Features a Dockerized RESTful API built with C#/.NET, Entity Framework Core, PostgreSQL, and an upcoming React frontend for a complete vertical slice implementation.

## Technologies

- Backend Framework: .NET 10 (ASP.NET Core Web API)
- Database: PostgreSQL 16
- ORM: Entity Framework Core
- Containerization: Docker (for Database)
- Documentation: Swagger / OpenAPI
- Frontend: React (Planned)

## Prerequisites

- .NET 10 SDK
- Docker Desktop
- Visual Studio
- PostgreSQL Client (e.g., DBeaver) - _Optional_

## Getting Started

### 1. Database Setup

The application requires a PostgreSQL instance running via Docker.

```PowerShell
docker run --name dev-contacts-db -e POSTGRES_PASSWORD=wordpass42 -p 5432:5432 -d postgres
```

### 2. Configuration

Ensure the connection string in `appsettings.json` matches your Docker configuration:

```JSON
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=DevContactsDb;Username=postgres;Password=wordpass42"
}
```

### 3. Application Setup

1. Open the solution in Visual Studio.
2. Open the Package Manager Console.
3. Apply database migrations to create the schema:

```PowerShell
Update-Database
```

### 4. Running the API

Run the application via Visual Studio. The API will launch and the Swagger UI documentation will be available at:
`http://localhost:5243/swagger`

## Roadmap

- [x] Backend Infrastructure: .NET 9 API setup with Dependency Injection.
- [x] Data Layer: EF Core integration with PostgreSQL.
- [ ] Frontend Implementation: React SPA for contact management.
- [ ] Containerization: Full Docker Compose support for all services.
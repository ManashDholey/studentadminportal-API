# studentadminportal

Project Title: studentadminportal

Description
This project is a web application built using .NET Core for the backend and Angular for the frontend. It implements a variety of design patterns and practices, including the Repository and Unit of Work patterns, Specification pattern, caching, AutoMapper, FluentValidation, Swagger, and static file handling for uploaded resources.

The repository (studentadminportal-API) contains the backend Web API. The frontend lives in a separate repository (studentadminportal-ui).

Features

- .NET Core (Backend)
  - RESTful API development
  - Repository and Unit of Work Pattern for data access
  - Specification Pattern for complex querying
  - Caching strategies for improved performance
  - AutoMapper for DTO mapping
  - FluentValidation for request validation
  - Swagger/OpenAPI for API documentation
  - Static file serving for uploaded resources

- Angular (Frontend)
  - Lazy loading for optimized module loading
  - Comprehensive Angular routing
  - Reactive Forms for handling form data
  - Multi-step form wizard for enhanced user experience
  - Re-usable form components for consistency
  - Validation and async validation for robust form handling
  - Stripe integration for payment processing

Quick summary (backend)
- Framework: .NET 8 (ASP.NET Core Web API)
- ORM: Entity Framework Core (SQL Server provider)
- Validation: FluentValidation
- Mapping: AutoMapper
- API docs: Swagger / Swashbuckle
- Static files: served from `Resources` folder (mapped to `/Resources`)
- CORS: configured for Angular dev origin `http://localhost:4200`

Repository layout (top-level):
- `studentadminportal-API/` — main Web API project (Program.cs, controllers, data models, repositories, migrations, resources)
- `studentadminportal-API.sln` — Visual Studio / dotnet solution
- Frontend (separate repo): `studentadminportal-ui`

Key files (backend)
- Program.cs: `studentadminportal-API/Program.cs`
- Configuration: `studentadminportal-API/appsettings.json` / `appsettings.Development.json`
- Project file: `studentadminportal-API/studentadminportal-API.csproj`
- Migrations: `studentadminportal-API/Migrations`

Getting Started

Prerequisites
Before you begin, ensure you have the following installed on your machine:

- .NET 8.0 SDK
- Node.js (v18.10.0 recommended)
- Angular CLI (v16.2.12 recommended)
- SQL Server (local / container / remote) or another SQL Server-compatible instance
- (Optional) Docker (for running SQL Server in a container if needed)

Installation

1. Clone the repositories
```bash
git clone https://github.com/ManashDholey/studentadminportal-API.git
git clone https://github.com/ManashDholey/studentadminportal-ui.git
```

2. Restore dependencies and build the backend
```bash
cd studentadminportal-API
dotnet restore
dotnet build
```

3. Configure the database connection
Update the SQL Server connection string in `appsettings.json` or `appsettings.Development.json` according to your local environment.

4. Run database migrations and start the API
```bash
dotnet ef database update
# or if EF CLI is not installed globally:
dotnet tool restore
dotnet ef database update

dotnet run
```

5. Open Swagger
Once the API is running, visit:
- https://localhost:5001/swagger
- or http://localhost:5000/swagger

#### Live URL
http://kumardholey-001-site1.htempurl.com/swagger/index.html

About this repository
This repository is the backend foundation for the Student Admin Portal. It provides a clean, scalable REST API for managing student-related data, admin operations, and business workflows. The API is designed to support a modern web frontend while keeping business logic, validation, and data access separated in a maintainable structure.

The codebase follows a layered architecture approach, making it easier to evolve features without tightly coupling controllers, repositories, services, and database logic. The project also includes support for uploaded resources, validation, and API documentation, which makes it easier for both developers and consumers to understand and use the service.

Project purpose
The main goal of this project is to provide a secure and extensible backend for a student administration platform. It can be used to manage records, academic workflows, resource uploads, and API-driven operations that are consumed by an Angular frontend or other clients.

Architecture overview
The backend follows a modular structure built around common enterprise patterns:
- Controllers handle HTTP requests and responses.
- Repositories isolate database operations and query logic.
- Unit of Work coordinates transactions and repository access.
- Specification pattern supports reusable query filtering and sorting.
- AutoMapper converts domain entities to DTOs and vice versa.
- FluentValidation validates incoming requests before they reach business logic.
- Swagger exposes the API contract for testing and documentation.

This separation keeps the API maintainable, testable, and easier to extend as new modules are added.

Typical repository structure
The project is organized to keep domain logic and infrastructure concerns separated:
- `Controllers/` — API endpoints and request handling
- `Data/` — database context and EF Core models
- `Models/` — entity and domain classes
- `Repositories/` — repository implementations
- `Services/` or business logic areas — application logic and workflows
- `DTOs/` — data transfer objects for clean API contracts
- `Helpers/` — utility and supporting classes
- `Migrations/` — EF Core migration history
- `Resources/` — static files and uploaded content served by the API
- `Program.cs` — application startup and configuration

Configuration and environment
The backend uses ASP.NET Core configuration and can be customized using:
- `appsettings.json`
- `appsettings.Development.json`

Typical configuration includes:
- database connection strings
- CORS settings
- API environment settings
- static file configuration

For local development, the Angular frontend is expected to run on `http://localhost:4200`, and the API is configured to accept requests from that origin.

Development notes
- The project is built with .NET 8 and is compatible with current ASP.NET Core tooling.
- EF Core is used for persistence and schema management.
- The API is designed to be consumed by the separate Angular frontend repository.
- Swagger is enabled to simplify backend testing and documentation.
- Static uploaded resources are exposed via a dedicated resource path.

Related repositories
- Backend: https://github.com/ManashDholey/studentadminportal-API
- Frontend: https://github.com/ManashDholey/studentadminportal-ui

Contribution and usage
This repository is intended to serve as a practical example of a structured .NET backend using modern API patterns. It is suitable for learning, extending, and adapting to real-world student administration features or similar enterprise application needs.

If you are working on this project locally, make sure to keep the API and frontend repositories aligned, especially when changing shared models, routes, or authentication-related behavior.



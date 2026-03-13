# studentadminportal

Project Title: studentadminportal

Description
This project is a web application built using .NET Core for the backend and Angular for the frontend. It implements a variety of design patterns and practices, including the Repository and Unit of Work patterns, the Specification pattern, caching strategies, and more. The application also includes features such as lazy loading, reactive forms, a multi-step form wizard, and payment processing with Stripe.

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
   
#### Live URL   
   http://kumardholey-001-site1.htempurl.com/swagger/index.html
   

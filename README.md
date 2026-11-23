# Chesed – Volunteer Task Management API

A REST API for managing volunteer tasks ("chesed" – acts of kindness): create tasks, match them to volunteer skills, track their status, and search them by skill, date and location.

Built with **C#**, **ASP.NET Core (.NET 8)** and **Entity Framework Core** on **SQL Server**, using a layered architecture split into separate projects.

## Features

- **Task management** – create, update and view volunteer tasks
- **Status workflow** – each task moves between `open`, `checkered` (in progress) and `completed`, with a dedicated endpoint to update the status
- **Filtering and sorting** – filter tasks by skill, date and location, list only open tasks, and sort by date or location
- **Skills** – every task is linked to a skill, and volunteers can have many skills (many-to-many)
- **Input validation** – task descriptions are validated before saving, with clear error responses
- **Interactive API docs** – Swagger UI for exploring and testing the endpoints

## Tech Stack

| Area | Technology |
|------|------------|
| Language | C# |
| Framework | ASP.NET Core Web API (.NET 8) |
| Data access | Entity Framework Core with migrations |
| Database | SQL Server (LocalDB) |
| API docs | Swagger / OpenAPI (Swashbuckle) |

## Architecture

The solution is split into four projects, each with one responsibility. Requests flow from the API down to the database:

```
Chesed (API)  →  Service  →  Repository  →  Entities
 Controllers     Business      EF Core        Domain
                 logic, DTOs   DataContext    models
```

| Project | Folder | Role |
|---------|--------|------|
| API | `Chesed/` | Controllers, routing, Swagger |
| Service | `Serevers/` | Business rules, validation, mapping to DTOs (`TaskToAdd`, `TaskToShow`, `TaskToUpdate` as C# records) |
| Repository | `Repotroty/` | `DataContext`, repositories and EF Core migrations |
| Entities | `Entities/` | Domain models: `TaskVolunteer`, `Volunteer`, `Skills`, `Assignment` |

## API Endpoints

Base route: `/api/TaskControllers`

| Method | Route | Description |
|--------|-------|-------------|
| GET | `/` | All tasks; optional `?sortBy=date` or `?sortBy=location` |
| GET | `/{id}` | A single task |
| POST | `/` | Create a task |
| PUT | `/{id}` | Update a task |
| PUT | `/{id}/status` | Update only the status |
| GET | `/filterTaskOpened` | Only open tasks |
| GET | `/filters` | Filter by `skill`, `dateTask` and/or `location` |

## Getting Started

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download) and SQL Server LocalDB (included with Visual Studio).

1. Open `Chesed.sln` in Visual Studio.
2. Create the database from the migrations (Package Manager Console, default project: `Repository`):
   ```
   Update-Database
   ```
3. Add at least one skill to the `Skills` table – every task must be linked to a skill.
4. Run the `Chesed` project and open `/swagger` in the browser.

## Author

**Ayala Cohen** – [GitHub](https://github.com/AyalaCohenCode)

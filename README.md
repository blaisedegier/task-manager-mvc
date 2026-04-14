# Basic Task Manager ✅

A simple **ASP.NET Core MVC** web application for managing tasks with full **CRUD** (Create, Read, Update, Delete) functionality. Built with .NET 8, Razor views, and Bootstrap 5.

---

## Table of Contents

- [Features](#features)
- [Tech Stack](#tech-stack)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Routes](#routes)
- [Data Model](#data-model)
- [Known Limitations](#known-limitations)

---

## Features

- **View tasks:** Browse all tasks in a clean, tabular layout
- **Create tasks:** Add new tasks with a title, description, and deadline
- **Edit tasks:** Update existing task details
- **Delete tasks:** Remove tasks with a confirmation step
- **Client-side validation:** Instant form feedback via jQuery unobtrusive validation
- **Responsive UI:** Mobile-friendly design powered by Bootstrap 5

---

## Tech Stack

| Layer      | Technology                                                           |
| ---------- | -------------------------------------------------------------------- |
| Framework  | [ASP.NET Core MVC](https://learn.microsoft.com/aspnet/core) (.NET 8) |
| Language   | C# 12                                                                |
| Views      | Razor (`.cshtml`)                                                    |
| CSS        | [Bootstrap 5](https://getbootstrap.com/)                             |
| JavaScript | [jQuery](https://jquery.com/) + jQuery Validation                    |
| Storage    | In-memory (`List<TaskModel>`)                                        |

---

## Project Structure

```text
BasicTaskManager/
├── BasicTaskManager.sln                  # Visual Studio solution
├── BasicTaskManager/
│   ├── BasicTaskManager.csproj           # Project file (.NET 8)
│   ├── Program.cs                        # Application entry point & middleware
│   ├── appsettings.json                  # App configuration
│   ├── Controllers/
│   │   ├── HomeController.cs             # Home & Privacy pages
│   │   └── TaskController.cs             # Task CRUD actions
│   ├── Models/
│   │   ├── TaskModel.cs                  # Task entity with validation
│   │   └── ErrorViewModel.cs             # Error page model
│   ├── Views/
│   │   ├── Home/                         # Home & Privacy views
│   │   ├── Task/                         # Task CRUD views
│   │   └── Shared/                       # Layout & partial views
│   ├── Properties/
│   │   └── launchSettings.json           # Local launch profiles
│   └── wwwroot/                          # Static assets
│       ├── css/site.css
│       ├── js/site.js
│       └── lib/                          # Vendored client libraries
│           ├── bootstrap/
│           ├── jquery/
│           ├── jquery-validation/
│           └── jquery-validation-unobtrusive/
└── README.md
```

---

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (or later)

Verify your installation:

```bash
dotnet --version
```

---

## Getting Started

1. **Clone the repository**

   ```bash
   git clone https://github.com/<your-username>/BasicTaskManager.git
   cd BasicTaskManager
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Build the project**

   ```bash
   dotnet build
   ```

4. **Run the application**

   ```bash
   dotnet run --project BasicTaskManager
   ```

5. **Open in your browser**

   | Profile | URL                      |
   | ------- | ------------------------ |
   | HTTP    | <http://localhost:5057>  |
   | HTTPS   | <https://localhost:7022> |

---

## Usage

| Action        | How                                                        |
| ------------- | ---------------------------------------------------------- |
| View tasks    | Navigate to `/Task` to see all tasks in a table            |
| Create a task | Click **Create New Task** and fill in the form             |
| Edit a task   | Click the **Edit** link next to any task                   |
| Delete a task | Click **Delete**, review the details, then confirm removal |

---

## Routes

The application uses ASP.NET Core's conventional routing pattern:
`{controller=Home}/{action=Index}/{id?}`

| Method | Route               | Description              |
| ------ | ------------------- | ------------------------ |
| `GET`  | `/`                 | Home page                |
| `GET`  | `/Home/Privacy`     | Privacy policy           |
| `GET`  | `/Task`             | List all tasks           |
| `GET`  | `/Task/Create`      | Create task form         |
| `POST` | `/Task/Create`      | Submit new task          |
| `GET`  | `/Task/Edit/{id}`   | Edit task form           |
| `POST` | `/Task/Edit/{id}`   | Submit task update       |
| `GET`  | `/Task/Delete/{id}` | Delete confirmation page |
| `POST` | `/Task/Delete/{id}` | Confirm and delete task  |

---

## Data Model

### `TaskModel`

| Property      | Type       | Constraints                     |
| ------------- | ---------- | ------------------------------- |
| `Id`          | `int`      | Auto-assigned                   |
| `Title`       | `string?`  | Required, max 100 characters    |
| `Description` | `string?`  | Optional, max 500 characters    |
| `Deadline`    | `DateTime` | Required, date format validated |

---

## Known Limitations

- **No persistent storage:** Tasks are stored in an in-memory list and are lost when the application restarts. To add persistence, integrate a database via Entity Framework Core.
- **No authentication:** The app is fully anonymous with no user accounts or access control.
- **No automated tests:** Unit and integration tests are not yet included.
- **Not thread-safe:** The static in-memory list is not protected against concurrent access, which is acceptable for local/demo use.

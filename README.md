# Task Manager

A small ASP.NET Core 8 MVC web app for creating, editing and deleting tasks with a title, description and deadline.

[![CI](https://github.com/blaisedegier/task-manager-mvc/actions/workflows/ci.yml/badge.svg)](https://github.com/blaisedegier/task-manager-mvc/actions/workflows/ci.yml)

## What it does

- Lists every task in a table, earliest deadline first.
- Adds a task with a required title (up to 100 characters), an optional description (up to 500
  characters) and a required deadline.
- Edits a task in place, and deletes one after a confirmation page.
- Validates forms in the browser (jQuery unobtrusive validation) and again on the server.

## How it works

`TaskController` holds the tasks in a static `List<TaskModel>`. MVC creates a new controller per request,
so the list has to be static to survive between requests, and because requests run concurrently every
read and write goes through a single lock. Ids are assigned as one more than the current highest id.

The validation rules live once, as data annotations on `TaskModel`; Razor tag helpers turn them into
client-side rules and `ModelState` enforces them on the server. Every POST action validates the
antiforgery token that the form tag helper emits.

| Method | Route | Purpose |
| --- | --- | --- |
| GET | `/` | Landing page |
| GET | `/Task` | Task list |
| GET, POST | `/Task/Create` | Add a task |
| GET, POST | `/Task/Edit/{id}` | Edit a task |
| GET, POST | `/Task/Delete/{id}` | Confirm and delete a task |

## Running it

Prerequisite: the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
git clone https://github.com/blaisedegier/task-manager-mvc.git
cd task-manager-mvc
dotnet build BasicTaskManager.sln -c Release
dotnet run --project BasicTaskManager/BasicTaskManager.csproj
```

The app listens on <http://localhost:5057> (the `http` launch profile). No configuration is needed.

## Tech

ASP.NET Core 8 MVC, Razor views, Bootstrap 5, jQuery Validation.

## Known limitations

- Tasks are held in memory only and are lost when the app restarts.
- There are no user accounts: everyone who can reach the app shares one task list.
- There are no automated tests.

# Library Management System - COM5009 CW2

ASP.NET Core MVC web app for a Library Management System.

## Features
- Login/logout with seeded admin account
- Dashboard statistics
- Book CRUD
- Member CRUD
- Borrow and return books
- SQLite database using Entity Framework Core
- Code-first models
- Data annotations validation
- Seed data
- Search books

## Demo Login
Username: `admin`
Password: `admin123`

## How to Run
1. Install .NET 8 SDK.
2. Open terminal in this project folder.
3. Run:

```bash
dotnet restore
dotnet run
```

4. Open the local URL shown in the terminal, for example `https://localhost:5001`.

The SQLite database `library.db` is created automatically using `EnsureCreated()` and seeded with sample books, members and an admin user.

## Migration Commands for Report
If your lecturer requires migrations instead of automatic creation, install EF tools and run:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Suggested Screenshots for Report
- Login page
- Dashboard
- Book list
- Add book
- Edit book
- Member list
- Add member
- Borrow book page
- Borrow records
- Returned book record

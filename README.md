# Inventory Management API

A RESTful backend API for managing product inventory, built with **ASP.NET Core 10** using Minimal APIs and **PostgreSQL** via Entity Framework Core.

## Tech Stack

- **.NET 10** — Minimal API architecture
- **PostgreSQL** — relational database with EF Core + Npgsql
- **Entity Framework Core 10** — ORM with code-first migrations
- **OpenAPI** — auto-generated API docs (Swagger UI in development)

## Features

- Full **CRUD** for products (create, read, update, delete)
- **Paginated product listing** with name search filter
- **SKU uniqueness** validation on creation
- **Stock threshold** tracking per product
- **Category** management and lookup
- Database **seeded** with initial categories and sample products

## Project Structure

```
Backend/
├── Data/
│   ├── Models/          # Product, Category entities
│   ├── Migrations/      # EF Core migrations
│   └── InventoryDbContext.cs
├── Features/
│   ├── Products/        # CRUD endpoints (Minimal API, feature-sliced)
│   └── Categories/      # GET categories endpoint
└── Program.cs
```

The project follows a **vertical slice / feature folder** pattern — each endpoint lives in its own folder with its DTO and handler.

## Getting Started

**Prerequisites:** .NET 10 SDK, PostgreSQL

```bash
# 1. Clone the repo
git clone <repo-url>

# 2. Set your connection string (user secrets recommended)
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Database=inventory;Username=postgres;Password=yourpassword"

# 3. Apply migrations
dotnet ef database update

# 4. Run
dotnet run
```

## API Endpoints

| Method   | Route            | Description                                   |
| -------- | ---------------- | --------------------------------------------- |
| `GET`    | `/products`      | List products (paginated, filterable by name) |
| `GET`    | `/products/{id}` | Get product by ID                             |
| `POST`   | `/products`      | Create product                                |
| `PUT`    | `/products/{id}` | Update product                                |
| `DELETE` | `/products/{id}` | Delete product                                |
| `GET`    | `/categories`    | List all categories                           |

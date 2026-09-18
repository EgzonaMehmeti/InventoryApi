Inventory System

A simple product inventory management system built with .NET 9 Web API, Entity Framework Core, SQL Server.

Technologies:
.NET 9
ASP.NET Core Web API
Entity Framework Core
SQL Server
Swagger / OpenAPI
Backend Setuп

Prerequisites:

Make sure the following are installed:

Visual Studio 2022
.NET 9 SDK
SQL Server LocalDB
1. Clone the repository
git clone <repository-url>
cd InventorySystem
2. Open the backend

Open the solution in Visual Studio 2022 and select the InventoryApi project as the startup project.

3. Configure the database

The backend uses SQL Server LocalDB.

The connection string is located in:

InventoryApi/appsettings.json

Default configuration:

"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=InventoryDb;Trusted_Connection=True;TrustServerCertificate=True;"
}

This configuration uses:

Server: (localdb)\MSSQLLocalDB
Database: InventoryDb
Authentication: Windows/Trusted Connection

If a different SQL Server instance is used, update the DefaultConnection value accordingly.

4. Create/update the database

Open Tools → NuGet Package Manager → Package Manager Console in Visual Studio.

Make sure InventoryApi is selected as the Default Project.

Run:

Update-Database

This applies the existing Entity Framework Core migrations and creates the InventoryDb database and required tables.

If the migrations have not been created yet, run:

Add-Migration InitialCreate

followed by:

Update-Database
5. Start the backend

Run the InventoryApi project from Visual Studio.

The API will start on the HTTPS URL configured by the Visual Studio launch settings.

Swagger can be accessed at:

https://localhost:<port>/swagger

Swagger provides an interactive interface for testing the API endpoints.

The database schema is managed using Entity Framework Core migrations.

API

The backend exposes the following product endpoints:

GET     /api/Products
GET     /api/Products/{id}
POST    /api/Products
PUT     /api/Products/{id}
DELETE  /api/Products/{id}
Current Implementation

The backend includes:

Product CRUD operations
DTOs
Service and Repository layers
Entity Framework Core
SQL Server
Input validation
Global exception handling
Swagger documentation

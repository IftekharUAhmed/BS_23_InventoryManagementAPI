# Inventory Management API

A robust RESTful API built with ASP.NET Core following the Clean Architecture principles. This project was developed as the final deliverable for the **.NET Fresher 2-Week Training Program** at **Brain Station 23**, serving as a comprehensive backend solution for managing products, categories, suppliers, and inventory transactions.

## Developer Details
* **Name:** Iftekhar Uddin Ahmed
* **Role:** Trainee
* **Company:** Brain Station 23

## Architecture
The solution is strictly structured following Clean Architecture to ensure separation of concerns, scalability, and maintainability:
* **Domain:** Core entities (Products, Categories, Suppliers, Users, InventoryTransactions).
* **Application:** Business logic, Interfaces, DTOs, Services, and FluentValidation.
* **Infrastructure:** Entity Framework Core, SQL Server Database context (DAL), and `Repositories` pattern implementations.
* **API:** RESTful endpoints, Controllers, Swagger UI, Global Exception Handling middleware, and JWT Authentication.

## Technologies & Tools Used
* **Framework:** .NET 10 & C#
* **Web:** ASP.NET Core Web API
* **ORM:** Entity Framework Core (Code-First Migration)
* **Database & Tools:** SQL Server Management Studio 22(SSMS)
* **Security:** JWT (JSON Web Tokens) & Role-Based Authorization
* **Core Libraries (NuGet):** 
  * `AutoMapper.Extensions.Microsoft.DependencyInjection`
  * `FluentValidation.DependencyInjectionExtensions`
  * `Microsoft.AspNetCore.Authentication.JwtBearer`
  * `Swashbuckle.AspNetCore` (Swagger UI)
  * `Microsoft.EntityFrameworkCore.SqlServer` & `Tools`
* **Deployment:** Docker (Containerization) & IIS

## How to Run Locally
1. Clone the repository to your local machine.
2. Update the SQL Server database connection string in `InventoryManagement.API/appsettings.json`.
3. Apply Database Migrations:
   * **Using Visual Studio (Package Manager Console):** Set the 'Default project' dropdown to `InventoryManagement.Infrastructure` and run `Update-Database`.
   * **Using .NET CLI:** Open terminal in the root solution folder and run: 
     `dotnet ef database update --project InventoryManagement.Infrastructure --startup-project InventoryManagement.API`
4. Run the project directly via Visual Studio (set `InventoryManagement.API` as the Startup Project), or build and run the provided `Dockerfile` using Docker Desktop.

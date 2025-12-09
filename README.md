# Employee List App – ASP.NET Core Web API (Backend)

A simple **Employee List Application** built using **ASP.NET Core Web API**, **Entity Framework Core**, and **MSSQL** as required by the technical exam.

This backend provides CRUD functionality for managing employees, including:

- Create new Employee  
- Update Employee  
- View Employee (by ID)  
- Delete Employee  
- View all Employees  
- *(Bonus Points)* Uses a **Stored Procedure** for fetching all employees  

---

##  Technologies Used
- **ASP.NET Core Web API (.NET 9)**
- **C#**
- **Entity Framework Core**
- **SQL Server (MSSQL)**
- **Swagger / OpenAPI**
- **AutoMapper**
- **Autofac (DI Container)**
- **Stored Procedure (Bonus Requirement)**

---

###  1. How to Clone the Project

Open Visual Studio and clone the repository:
https://github.com/PauloXedric/EmployeeListApp-backend.git

Or using Git:

git clone https://github.com/PauloXedric/EmployeeListApp-backend.git

---

###  2. Restore NuGet Packages

Visual Studio usually restores automatically.
If not:

1. Right-click the solution in Solution Explorer

2. Click Restore NuGet Packages

---

###  3. Configure the Application Settings

Open:

appsettings.Development.json

Replace the connection string and JWT key with your own:


```bash
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "MsSqlServerConnection": "DatabaseConnection" // Update it with your local database connection
  },
  "Jwt": {
    "Issuer": "EmployeeListApp",
    "Audience": "EmployeeListAppUsers",
    "Key": "" // GEnerate your key
  }
}
```

---

###  4. Apply EF Core Database Migrations

Step 1 - Visual Studio ➝ Tools ➝ NuGet Package Manager ➝ Package Manager Console

Step 2 — Run the Migration Command
Update-Database -Migration InitialCreate

---

###  5. Stored Procedure (BONUS REQUIREMENT)

Create the Stored Procedure in SQL Server

Steps to Create Stored Procedure

1. Open SQL Server Management Studio (SSMS)

2. Connect to your database (EmployeeListApp)

3. Click New Query

4. Paste the following SQL:

```bash
USE [YourDatabaseName];
GO

CREATE PROCEDURE [dbo].[sp_GetAllEmployees]
AS
BEGIN
    SELECT 
        Id,
        FirstName,
        LastName,
        Email,
        Position,
        DateHired,
        Salary
    FROM Employee;
END
GO
```

5. Press Execute or F5

6. Verify the Stored Procedure

**Databases → EmployeeListApp → Programmability → Stored Procedures**

You should see:

**dbo.sp_GetAllEmployees**


The API uses this in the repository:

```bash
// Used Stored Procedure for Bonus Points
public async Task<IEnumerable<EmployeeEntity>> GetAllAsync()
{
    return await _dbContext.Employee
        .FromSqlRaw("EXEC sp_GetAllEmployees")
        .ToListAsync();
}
```

---

###  6. Run the Application

Use IIS Express run from Visual Studio:

Press F5 or click Run

Swagger will open automatically

If not, manually enter:

```bash
https://localhost:(yourPort)/swagger/index.html
```

---


###  7. API Documentation (Swagger)

Swagger is already configured.

You can test all endpoints directly in the browser:

/swagger/index.html

## Frontend Repository
The backend (.NET Web API with Entity Framework + MSSQL) is hosted separately:

https://github.com/PauloXedric/EmployeeListApp-frontend

# This project was created as the 324th Papara .Net Bootcamp Week 1 Case Study.

This project is a RESTful API developed in .NET 8. It adheres to REST standards and provides CRUD operations using GET, POST, PUT, DELETE, and PATCH methods. The API handles HTTP status codes correctly and ensures that error responses for 500, 400, 404, 200, and 201 statuses are returned in a standard format. Model validation is performed for required fields, and routing is implemented. Model binding examples are provided for both body and query parameters.

## Features

- **CRUD Operations**: Supports GET, POST, PUT, DELETE, and PATCH methods.
- **HTTP Status Codes**: Follows standard HTTP status codes with error handling for 500, 400, 404, 200, and 201 statuses.
- **Model Validation**: Ensures required fields in models are validated.
- **Routing**: Implements routing for API endpoints.
- **Model Binding**: Examples included for binding data from both body and query parameters.
- **Listing and Sorting**: Additional functionality for listing and sorting products, e.g., `/api/products/list?name=abc`.

## Getting Started

These instructions will help you set up and run the project on your local machine.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/)
- [Visual Studio](https://visualstudio.microsoft.com/)

### Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/MehmetOguzOzkan/PaparaCaseWeek1.git
   cd PaparaCaseWeek1

2. Configure the database connection string in `appsettings.json`:
   ```sh
   "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=database_name;User=root;Password=your_password;" }

3. Install the required packages using NuGet Package Manager Console:
   ```sh
   Install-Package Microsoft.EntityFrameworkCore.Design
   Install-Package Microsoft.EntityFrameworkCore.Tools
   Install-Package Pomelo.EntityFrameworkCore.MySql

4. Create and apply the initial migration:
   ```sh
   Add-Migration InitialCreate
   Update-Database

### Running the Project
1. Open the project in Visual Studio.
2. Set the project as the startup project.
3. Press F5 to run the application.

### API Endpoints
(Docs/api_endpoints_swagger.jpg)

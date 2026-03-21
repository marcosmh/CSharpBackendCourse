# Backend en C# .NET

### .Net
* SDK DE .NET:
        - Version: 8

* Entorno de tiempo de ejecución:
  - OS Name:     Mac OS X
  - OS Version:  13.6
  - OS Platform: Darwin
  - Architecture: x64

* Visual Studio 2022 para Mac OS


### Instalar Entity Framework para MS SQL Sever
* dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.18

### Instalar Entity Framework para PosgreSQL
* dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.18

### Instalar Entity Framework para MySQL
* dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.18

### Migraciones y Comandos 
* dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.18


### Comandos para migraciones hacia base de datos

Nota: crear la base de datos manualmente

* dotnet ef migrations add InitialCreate

* dotnet ef database update

* dotnet ef migrations add AlcoholInBeer (modificacion agregando campo)

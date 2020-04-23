﻿Install NuGet packages
The following NuGet packages should be added to work with the SQL Server database and scaffolding. Run these commands in Package Manager Console:

Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design This package helps generate controllers and views.
Install-Package Microsoft.EntityFrameworkCore.Tools This package helps create database context and a model class from the database.
Install-Package Microsoft.EntityFrameworkCore.SqlServer  The database provider allows Entity Framework Core to work with SQL Server.



Scaffolding
ASP.NET Core has a feature called scaffolding, which uses T4 templates to generate code of common functionalities to help keep developers from writing repeat code. We use scaffolding to perform the following operations:

Generate entity POCO classes and a context class for the database.
Generate code for create, read, update, and delete (CRUD) operations of the database model using Entity Framework Core, which includes controllers and views.
Connect application with database
Run the following scaffold command in Package Manager Console to reverse engineer the database to create database context and entity POCO classes from tables. The scaffold command will create POCO class only for the tables that have a primary key.

Scaffold-DbContext “Server=LAPTOP-IFRMU6GH\MSSQLSERVER19;Database=SchoolRecognition;User Id=sa;Password=sa@123;” Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

For enquiries call +2348066744424 or Email patlichengine@gmail.com


Note: You must install the following Nuget packages also
1. AutoMapper.Extensions.Microsoft.DependencyInjection
2. Microsoft.AspNetCore.Mvc.NewtonsoftJson
# DotNetCoreClassLirary
DotNetCore Class Library with Repository Pattern

## Development server
To get the DotNetCore 5.0 locally:

- Clone this repo
- Download & install from here `https://dotnet.microsoft.com/download/dotnet/5.0`
- open .sln file from cloned repo

## Application Structure

- `program.cs` - The entry point to our application. This file defines console app with `DI`.

- `RepositoryPattern` - The structure has given in `EmployeeManagementLibrary` class library.

- `Migrations` - Migrations has alredy been stored in `Migrations` repository

- `localDB` - mssqllocaldb has been connected from here.

##Dependencies
- [EntityFrameworkCore] - To run with EF,
- [EntityFrameworkCore.SqlServer] - to store data locally
- [EntityFrameworkCore.tools] - for running Migrations
- [Microsoft.Extensions.DependencyInjection] - To resolve DependencyInjection
- [Microsoft.Extensions.Hosting] - to host our application
- [System.Collection.NonGeneric] - for using Hashtable

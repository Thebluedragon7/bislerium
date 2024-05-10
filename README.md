# Bislerium Private

The runnable ASP.NET MVC project is `WebApp` on `Bislerium` solution. The architecture is based on [Robert Cecil Martin](https://en.wikipedia.org/wiki/Robert_C._Martin)'s Clean Architecture with objective of [Separation of Concerns (SoC)](https://en.wikipedia.org/wiki/Separation_of_concerns).

## Setting up Database

### Setting up Connection String

Sql Server was used for development, the connection string is configured on `WebApp/appsettings.json`.
`ConnectionStrings` has an object with key `BisleriumPrivate` which consists of connection string.
This can be obtained from Visual Studio IDE after connecting the project to database.

### Updating Database from Migrations

Database Context file is located on: `Plugins/Plugins.DataStore.SQL/BisleriumContext.cs`
so to update database, Bislerium context on Plugins.DataStore.SQL should be done.

For example:

```
dotnet ef database update --project Plugins/Plugins.DataStore.SQL/Plugins.DataStore.SQL.csproj --startup-project WebApp/WebApp.csproj --context Plugins.DataStore.SQL.BisleriumContext --configuration Debug
```

or use NuGet package manager console to update database for `Plugins/Plugins.DataStore.SQL/BisleriumContext.cs`

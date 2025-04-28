# Dotnet project template

This repository is an example of a .net solution with hexagonal and DDD pattern.
It show :
- indepedent project for database behaviour
- business separated as module, each one having his web/application/infra/domain layers
- EF Core as ORM
- separation between domain models and database models

### Hexagonal

Each module as a `Ports` .net project, with a Inbounds and OutBounds directory.
#### Inbounds
Contain abstractions of what the domain can do (services, business validations)

#### OutBounds
Contain abstractions for the infra layer (repositories)

### DDD

Domain of different layers does not depend of each others, they pass through the `Ports` projects to access abstractions. They are isolated from any other module layers.


## Migrations

### Add
`dotnet ef migrations add migrationName --project Database\SaM.Database.Migrations --startup-project SaM.Start`

### Update database
`dotnet ef database update --project Database/SaM.Database.Migrations`
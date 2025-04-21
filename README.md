## Migrations

### Add
`dotnet ef migrations add migrationName --project Database\SaM.Database.Migrations --startup-project SaM.Start`

### Update database
`dotnet ef database update --project Database/SaM.Database.Migrations`
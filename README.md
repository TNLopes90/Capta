## Capta

### Create migration and database

dotnet ef --startup-project ..\Capta.WebAPI\  migrations add init
dotnet ef --startup-project ..\Capta.WebAPI\  database update
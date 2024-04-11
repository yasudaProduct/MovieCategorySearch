# MovieCategorySearch
MovieCategorySearch


#### ・マイグレーションの実行

```
dotnet ef migrations add CreateTable --project ./MovieCategorySearch.Infrastructure/MovieCategorySearch.Infrastructure.csproj --startup-project ./MovieCategorySearch/MovieCategorySearch.csproj --context PostgresDbContext --output-dir ./MovieCategorySearch.Infrastructure/Data/Migrations

dotnet ef database update --project ./MovieCategorySearch.Infrastructure/MovieCategorySearch.Infrastructure.csproj --startup-project ./MovieCategorySearch/MovieCategorySearch.csproj --context PostgresDbContext

dotnet ef database drop -f -v --context PostgresDbContext
```
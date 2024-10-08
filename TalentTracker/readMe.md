
## Caching

It is utilized when checking the existing user, which will
1. reduce the database load
2. enable faster user lookups
3. beneficial for scenarios where user might perform faster updates or checks

There are opportunities for improvement, especially in managing the cache, but I haven't included that since there is no delete operation.

## Architectural Pattern

I have implemented Clean Architecture with a focus on modularity, following a Modular Monolithic concept.

## Database

I have used EF Core for database management. The Migrations folder is already available. so you can update the database schema by running the following command:

dotnet ef database update

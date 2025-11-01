# MealPlanner

This is a project to help me generate a groceries list depending on the recipes I want to make during the week

## Postgres

*Commands to get it running locally with docker*

`docker pull postgres`

`docker run --name local-postgres -e POSTGRES_PASSWORD=postgres -d -p 5432:5432 postgres`

The default postgres user is 'postgres'

Do you want a nice and easy docker UI? check this TUI out https://github.com/jesseduffield/lazydocker

## Migrations

### Generate migration

dotnet ef migrations add InitialCreate --startup-project ../Api

### Update database

dotnet ef database update --startup-project ../Api

## Bruno

In case you're wondering, what is Bruno?

Bruno is an api client that is awesome for testing your api, it's git friendly :)

https://www.usebruno.com/

## Result pattern

https://medium.com/@aseem2372005/the-result-pattern-in-c-a-smarter-way-to-handle-errors-c6dee28a0ef0
# MealPlanner

This is a project to help me generate a groceries list depending on the recipes I want to make during the week

SQLite docs
https://sqldocs.org/sqlite-entity-framework/
https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli


# Migrations

## Generate migration
dotnet ef migrations add InitialCreate --startup-project ../Presentation

## Update database
dotnet ef database update --startup-project ../Presentation
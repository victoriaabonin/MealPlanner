using System.Text.Json.Serialization;
using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IIngredientsRepository, IngredientsRepository>();
builder.Services.AddTransient<IIngredientsService, IngredientsService>();
builder.Services.AddTransient<IRecipesRepository, RecipesRepository>();
builder.Services.AddTransient<IRecipesService, RecipesService>();
builder.Services.AddTransient<IRecipeIngredientRepository, IngredientRecipesRepository>();

var configuration = builder.Configuration;
builder.Services.AddDbContext<MealPlannerDbContext>(options => options.UseSqlite(configuration.GetConnectionString("SQLiteConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
    {   
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using System.Text.Json.Serialization;
using Api.Middlewares;
using Application.Services;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddTransient<IIngredientsRepository, IngredientsRepository>();
builder.Services.AddTransient<IIngredientsService, IngredientsService>();
builder.Services.AddTransient<IRecipesRepository, RecipesRepository>();
builder.Services.AddTransient<IRecipesService, RecipesService>();
builder.Services.AddTransient<IRecipeIngredientRepository, IngredientRecipesRepository>();

var configuration = builder.Configuration;
builder.Services.AddDbContext<MealPlannerDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
    {   
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

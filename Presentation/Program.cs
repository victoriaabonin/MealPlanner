using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IIngredientsRepository, IngredientsRepository>();
builder.Services.AddTransient<IIngredientsService, IngredientsService>();
builder.Services.AddTransient<IRecipesRepository, RecipesRepository>();
builder.Services.AddTransient<IRecipesService, RecipesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

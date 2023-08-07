using JolliTradersHope.Api.Constants;
using JolliTradersHope.Api.Data;
using JolliTradersHope.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JolliDbContext>(options => 
        options.UseSqlServer(builder.Configuration
               .GetConnectionString(DatabaseConstants
               .GroceryConnectionStringKey)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mastersGroup = app.MapGroup("/masters").AllowAnonymous();

mastersGroup.MapGet("/categories", async (JolliDbContext context) =>
    await context.Categories
    .AsNoTracking()
    .ToArrayAsync()
    );
mastersGroup.MapGet("/offers", async (JolliDbContext context) =>
    await context.Offers
    .AsNoTracking()
    .ToArrayAsync()
    );

mastersGroup.MapGet("/users", async (JolliDbContext context) =>
    await context.Users
    .AsNoTracking()
    .ToArrayAsync()
    );

app.MapGet("/users", (JolliDbContext context) =>
{
    return context.Users;
});

app.MapGet("/users/{email}/{password}",async (JolliDbContext context, string email, string password) =>
{
    if (email != null || password != null)
    {
        User user = await context.Users
            .Where(x => x.Email!.ToLower().Equals(email.ToLower()) && x.Password == password)
            .FirstOrDefaultAsync();

        return user != null ? Results.Ok(user) : Results.NotFound("User not found");
    }
    return Results.BadRequest("Invalid Request");
});

app.MapGet("/popular-products", async (JolliDbContext context, int? count) =>
{
    if (!count.HasValue || count <= 0)
        count = 8;

    var randomProducts = await context.Products
                            .AsNoTracking()
                            .OrderBy(p => Guid.NewGuid())
                            .Take(count.Value)
                            .Select(Product.DtoSelector)
                            .ToArrayAsync();
    return TypedResults.Ok(randomProducts);
});

app.Run("https://localhost:12345");
using FundamentosEFPlatzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TareaContext>(opt => opt.UseInMemoryDatabase("TareaDB"));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TareaContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("Database InMemory:" + dbContext.Database.IsInMemory());
    });

app.Run();

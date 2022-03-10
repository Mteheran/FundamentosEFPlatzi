using FundamentosEFPlatzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareaContext>(opt => opt.UseInMemoryDatabase("TareaDB"));
builder.Services.AddSqlServer<TareaContext>("Data Source=server;Initial Catalog=db;user id=sa; password=pass");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TareaContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("Database InMemory:" + dbContext.Database.IsInMemory());
    });

app.Run();

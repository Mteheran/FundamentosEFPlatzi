using System.Text.Json.Serialization;
using FundamentosEFPlatzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<TareaContext>(opt => opt.UseInMemoryDatabase("TareaDB"));
builder.Services.AddSqlServer<TareaContext>(builder.Configuration.GetConnectionString("cnTareasDb"));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconection", async ([FromServices] TareaContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("Database InMemory:" + dbContext.Database.IsInMemory());
    });

app.MapGet("/api/tareas", async ([FromServices] TareaContext dbContext) =>
{
    return Results.Ok(dbContext.Tareas.Include(p=> p.Categoria));
});

app.Run();

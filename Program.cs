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

app.MapPost("/api/tareas", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual!=null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Descripcion = tarea.Descripcion;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
   
    return Results.NotFound();
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromRoute] Guid id) =>
{
    var tareaActual = dbContext.Tareas.Find(id);

    if(tareaActual !=null)
    {       
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }
   
    return Results.NotFound();
});



app.Run();

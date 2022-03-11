using Microsoft.EntityFrameworkCore;

namespace FundamentosEFPlatzi;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias {get;set;}
    public DbSet<Tarea> Tareas {get;set;}
    public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categorias = new List<Categoria>();
        Guid categoriaid1 = Guid.NewGuid();
        Guid categoriaid2 = Guid.NewGuid();
        categorias.Add(new Categoria() { CategoriaId = categoriaid1, Nombre = "Pendientes" });
        categorias.Add(new Categoria() { CategoriaId = categoriaid2, Nombre = "Actividad personal" });

        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");

            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(250);

            categoria.Property(p=> p.Descripcion).IsRequired(false);

            categoria.HasData(categorias);
        });       


        List<Tarea> tareasSeed = new List<Tarea>();
        tareasSeed.Add(new Tarea() { TareaId = Guid.NewGuid(), CategoriaId = categoriaid1, Titulo="Revisar la tesis de grado", PrioridadTarea = Prioridad.Alta, FechaCreacion = DateTime.Now});
        tareasSeed.Add(new Tarea() { TareaId = Guid.NewGuid(), CategoriaId = categoriaid2, Titulo="Comprar nuevo comic de batman", PrioridadTarea = Prioridad.Baja, FechaCreacion = DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");

            tarea.HasKey(p=> p.TareaId);

            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);

            tarea.Property(p=> p.Titulo).HasMaxLength(150);

            tarea.Property(p=> p.Descripcion).IsRequired(false);

            tarea.Property(p=> p.PrioridadTarea);

            tarea.Property(p=> p.FechaCreacion);

            tarea.Ignore(p=> p.Resumen);

            tarea.HasData(tareasSeed);

        });

    }        
}

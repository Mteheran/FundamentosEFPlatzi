using Microsoft.EntityFrameworkCore;

namespace FundamentosEFPlatzi;

public class TareaContext : DbContext
{
    DbSet<Categoria> Categorias {get;set;}
    DbSet<Tarea> Tareas {get;set;}
    public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(categoria=>
        {
            categoria.ToTable("Categoria");

            categoria.HasKey(p=> p.CategoriaId);

            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p=> p.Descripcion);
        });       

        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");

            tarea.HasKey(p=> p.TareaId);

            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaId);

            tarea.Property(p=> p.Titulo).HasMaxLength(150);

            tarea.Property(p=> p.Descripcion);

            tarea.Property(p=> p.PrioridadTarea);

            tarea.Property(p=> p.FechaCreacion);

            tarea.Ignore(p=> p.Resumen);

        });

    }        
}

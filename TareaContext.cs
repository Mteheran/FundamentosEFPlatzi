using Microsoft.EntityFrameworkCore;

namespace FundamentosEFPlatzi;

public class TareaContext : DbContext
{
    DbSet<Categoria> Categorias {get;set;}
    DbSet<Tarea> Tareas {get;set;}
    public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }        
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FundamentosEFPlatzi;

public class Categoria
{
    //[Key]
    public Guid CategoriaId {get;set;}

    //[Required]
    //[MaxLength(500)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public int Peso {get;set;}

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get; set;}
}
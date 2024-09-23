

using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JWork.UI.Administracion.DataBase.Models;

[Table("ConceptoCalificacion")]
public partial class ConceptoCalificacion
{
    [Key]
    public int ConceptoCalificacionId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }
}

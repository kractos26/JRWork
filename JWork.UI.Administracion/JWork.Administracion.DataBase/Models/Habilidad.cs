

using SQLite;

using System.ComponentModel.DataAnnotations;
namespace JWork.UI.Administracion.DataBase.Models;

[Table("Habilidad")]
public partial class Habilidad
{
    [Key]
    public int HabilidadId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? ActividadId { get; set; }

    public virtual Actividad? Actividad { get; set; }
}

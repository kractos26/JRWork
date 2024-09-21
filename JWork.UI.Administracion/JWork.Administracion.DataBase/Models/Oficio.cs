

using SQLite;

using System.ComponentModel.DataAnnotations;
namespace JRWork.UI.Administracion.DataAccess.Models;

[Table("Oficio")]
public partial class Oficio
{
    [Key]
    public int OficioId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? AreaId { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual Area? Area { get; set; }
}

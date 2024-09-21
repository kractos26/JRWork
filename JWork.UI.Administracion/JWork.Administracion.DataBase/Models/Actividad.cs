using Microsoft.EntityFrameworkCore;
using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JRWork.UI.Administracion.DataAccess.Models;

[Table("Actividad")]
public partial class Actividad
{
    [Key]
    public int ActividadId { get; set; }

    public string Nombre { get; set; } = null!;

    public int? OficioId { get; set; }

    public virtual ICollection<Habilidad> Habilidads { get; set; } = new List<Habilidad>();

    public virtual Oficio? Oficio { get; set; }
}

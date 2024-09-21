

using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JRWork.UI.Administracion.DataAccess.Models;

[Table("Area")]
public partial class Area
{
    [Key]
    public int AreaId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Oficio> Oficios { get; set; } = new List<Oficio>();
}

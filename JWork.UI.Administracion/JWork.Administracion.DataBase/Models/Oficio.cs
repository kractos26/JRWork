

namespace JRWork.UI.Administracion.DataAccess.Models;

public partial class Oficio
{
    public int OficioId { get; set; }

    public string? Nombre { get; set; }

    public int? AreaId { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual Area? Area { get; set; }
}

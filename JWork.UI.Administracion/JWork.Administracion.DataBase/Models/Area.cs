

using System.ComponentModel.DataAnnotations;

namespace JWork.UI.Administracion.DataBase.Models;

public class Area
{
    [Key]
    public int AreaId { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Oficio> Oficios { get; set; } = new List<Oficio>();
}

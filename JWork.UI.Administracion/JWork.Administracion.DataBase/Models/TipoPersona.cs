
using SQLite;

using System.ComponentModel.DataAnnotations;
namespace JRWork.UI.Administracion.DataAccess.Models;

[Table("TipoPersona")]
public partial class TipoPersona
{
    [Key]
    public int TipoPersonaId { get; set; }

    public string Nombre { get; set; } = null!;
}

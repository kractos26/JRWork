
using SQLite;

using System.ComponentModel.DataAnnotations;
namespace JWork.UI.Administracion.DataBase.Models;

[Table("TipoPersona")]
public partial class TipoPersona
{
    [Key]
    public int TipoPersonaId { get; set; }

    public string Nombre { get; set; } = null!;
}

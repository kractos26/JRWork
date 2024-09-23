

using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JWork.UI.Administracion.DataBase.Models;

[Table("TipoDocumento")]
public partial class TipoDocumento
{
    [Key]
    public int TipoDocumentoId { get; set; }

    public string Nombre { get; set; } = null!;
}

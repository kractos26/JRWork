using SQLite;

using System.ComponentModel.DataAnnotations;
namespace JRWork.UI.Administracion.DataAccess.Models;

[Table("UnidadMedida")]

public partial class UnidadMedida
{
    [Key]
    public int UnidadMedidaId { get; set; }

    public string Nombre { get; set; } = null!;
}

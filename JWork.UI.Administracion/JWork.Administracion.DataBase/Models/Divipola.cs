using SQLite;
using System.ComponentModel.DataAnnotations;

namespace JRWork.UI.Administracion.DataAccess.Models;

[Table("Divipola")]
public partial class Divipola
{
    [Key]
    public int DivipolaId { get; set; }

    public decimal Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? CodigoPadre { get; set; }
}

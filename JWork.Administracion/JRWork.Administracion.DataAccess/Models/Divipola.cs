namespace JRWork.Administracion.DataAccess.Models;

public partial class Divipola
{
    public int DivipolaId { get; set; }

    public decimal Codigo { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal? CodigoPadre { get; set; }
}

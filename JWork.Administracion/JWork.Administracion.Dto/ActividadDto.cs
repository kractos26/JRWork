using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Dto;

public class ActividadDto
{
    public int ActividadId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Campo obligatorio")]
    public int OficioId { get; set; }
}

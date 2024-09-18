using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Dto;

public class HabilidadDto
{
    public int HabilidadId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "Campo obligatorio")]
    public int ActividadId { get; set; }

    public ActividadDto? Actividad { get; set; }

}

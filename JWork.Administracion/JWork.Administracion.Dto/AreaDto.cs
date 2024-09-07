using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Dto;

public class AreaDto
{
    public int AreaId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string Nombre { get; set; } = null!;
}

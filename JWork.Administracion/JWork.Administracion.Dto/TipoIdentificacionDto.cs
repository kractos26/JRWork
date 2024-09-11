using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Dto;

public class TipoIdentificacionDto
{
    public int TipoDocumentoId { get; set; }
    [Required(ErrorMessage = "Campo obligatorio")]
    public string Sigla { get; set; } = null!;
    [Required(ErrorMessage = "Campo obligatorio")]
    public string Nombre { get; set; } = null!;
}

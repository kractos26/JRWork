using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Dto;

public class TipoDocumentoDto
{
    public int TipoDocumentoId { get; set; }

    [Required(ErrorMessage = "Campo obligatorio")]
    public string Nombre { get; set; } = null!;
}

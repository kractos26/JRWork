using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Dto;

public class TipoPersonaDto
{
    public int TipoPersonaId { get; set; }

    [Required(ErrorMessage = "Campo es obligatorio")]
    public string Nombre { get; set; } = null!;
}

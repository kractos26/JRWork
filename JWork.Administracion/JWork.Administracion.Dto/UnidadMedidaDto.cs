using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Dto;

public class UnidadMedidaDto
{
    public int UnidadMedidaId { get; set; }

    [Required(ErrorMessage = "Campo es obligatorio")]

    public string? Nombre { get; set; }
}

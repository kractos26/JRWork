namespace JWork.UI.Administracion.Models;

public class HabilidadDto
{
    public int HabilidadId { get; set; }

    
    public string Nombre { get; set; } = null!;

   
    public int ActividadId { get; set; }

    public ActividadDto? Actividad { get; set; }

}

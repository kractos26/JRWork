namespace JWork.UI.Administracion.Models.Request
{
    public class ActividadRequest
    {
        public int ActividadId { get; set; }

        public string Nombre { get; set; } = null!;

        public int OficioId { get; set; }
    }
}

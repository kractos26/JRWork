namespace JWork.Administracion.Dto
{
    public class OficioDto
    {
        public int OficioId { get; set; }

        public string Nombre { get; set; } = null!;

        public int AreaId { get; set; }

        public AreaDto? Area { get; set; }

    }
}

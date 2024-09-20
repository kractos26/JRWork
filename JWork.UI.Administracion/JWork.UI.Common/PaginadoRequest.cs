namespace JWork.UI.Administracion.Common
{
    public class PaginadoRequest<T>
    {
        public T Entidad { get; set; }
        public int NumeroPagina { get; set; }
        public int TotalRegistros { get; set; }
    }
}

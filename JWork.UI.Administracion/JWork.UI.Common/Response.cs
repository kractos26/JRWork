using System.Net;

namespace JWork.UI.Administracion.Common;

public class Response<T>
{
   public T? Entidad { get; set; }
   public string? Mensaje { get; set; }
    public HttpStatusCode Status { get; set; }

}

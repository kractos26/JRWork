﻿using System.Net;

namespace JWork.Administracion.WebApi.Models
{
    public class RespustaViewModel<T>
    {
       public T? Entidad { get; set; }
       public string? Mensaje { get; set; }
        public HttpStatusCode Status { get; set; }

    }
}

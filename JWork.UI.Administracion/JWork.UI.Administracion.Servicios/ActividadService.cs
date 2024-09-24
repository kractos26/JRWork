using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Models.Request;

namespace JWork.UI.Administracion.Servicios
{
    public class ActividadService
    {

        public async Task<Response<ActividadDto>> CrearAsync(ActividadDto actividad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.UrlActividad.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Post,
                Parametros = actividad
            };
            return await ServicioRest.EjecutarServicioAsync<Response<ActividadDto>>(servicio) ?? new Response<ActividadDto>();
        }

        public async Task<Response<ActividadDto>> ModificarAsync(ActividadDto actividad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.UrlActividad.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Put,
                Parametros = actividad
            };
            return await ServicioRest.EjecutarServicioAsync<Response<ActividadDto>>(servicio) ?? new Response<ActividadDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"api/Actividad/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<ActividadDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.UrlActividad.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<ActividadDto>>>(servicio) ?? new();
        }

        public async Task<Response<ActividadDto>> BuscarPorIdAsync(int actividad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.UrlActividad.GetPorIdAsync}/{actividad}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<ActividadDto>>(servicio) ?? new Response<ActividadDto>();
        }

        public async Task<Response<List<ActividadDto>>> Buscar(ActividadRequest actividad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.UrlActividad.Buscar,
                Verbo = Verbo.Get,
                Parametros = actividad,
                ValidarSertificado = false
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<ActividadDto>>>(servicio) ?? new();
        }
    }
}

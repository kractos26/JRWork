using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Servicios
{
    public class TipoIdentificacionService
    {

        public async Task<Response<TipoIdentificacionDto>> CrearAsync(TipoIdentificacionDto TipoIdentificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoIdentificacion.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Post,
                Parametros = TipoIdentificacion
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoIdentificacionDto>>(servicio) ?? new Response<TipoIdentificacionDto>();
        }

        public async Task<Response<TipoIdentificacionDto>> ModificarAsync(TipoIdentificacionDto TipoIdentificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoIdentificacion.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Put,
                Parametros = TipoIdentificacion
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoIdentificacionDto>>(servicio) ?? new Response<TipoIdentificacionDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"api/TipoIdentificacion/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<TipoIdentificacionDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.TipoIdentificacion.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoIdentificacionDto>>>(servicio) ?? new();
        }

        public async Task<Response<TipoIdentificacionDto>> BuscarPorIdAsync(int TipoIdentificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.TipoIdentificacion.GetPorIdAsync}/{TipoIdentificacion}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoIdentificacionDto>>(servicio) ?? new Response<TipoIdentificacionDto>();
        }

        public async Task<Response<List<TipoIdentificacionDto>>> Buscar(TipoIdentificacionDto TipoIdentificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.TipoIdentificacion.Buscar,
                Verbo = Verbo.Get,
                Parametros = TipoIdentificacion

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoIdentificacionDto>>>(servicio) ?? new();
        }
    }
}

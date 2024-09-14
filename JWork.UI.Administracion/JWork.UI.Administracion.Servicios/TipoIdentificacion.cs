using JWork.Administracion.Dto;
using JWork.UI.Administracion.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class TipoIdentificacionService
    {
        private readonly Settings settings;

        // Constructor
        public TipoIdentificacionService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<TipoIdentificacionDto>> CrearAsync(TipoIdentificacionDto TipoIdentificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoIdentificacion.Post,
                UrlBase = settings.UrlBFF,
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
                UrlBase = settings.UrlBFF,
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
                UrlBase = settings.UrlBFF,
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
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.TipoIdentificacion.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoIdentificacionDto>>>(servicio) ?? new();
        }

        public async Task<Response<TipoIdentificacionDto>> BuscarPorIdAsync(int TipoIdentificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.TipoIdentificacion.GetPorId}/{TipoIdentificacion}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoIdentificacionDto>>(servicio) ?? new Response<TipoIdentificacionDto>();
        }

        public async Task<Response<List<TipoIdentificacionDto>>> Buscar(TipoIdentificacionDto TipoIdentificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.TipoIdentificacion.Buscar,
                Verbo = Verbo.Get,
                Parametros = TipoIdentificacion

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoIdentificacionDto>>>(servicio) ?? new();
        }
    }
}

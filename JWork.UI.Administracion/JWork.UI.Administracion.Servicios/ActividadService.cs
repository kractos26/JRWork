using JWork.Administracion.Dto;
using JWork.UI.Administracion.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class ActividadService
    {
        private readonly Settings settings;

        // Constructor
        public ActividadService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<ActividadDto>> CrearAsync(ActividadDto actividad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.UrlActividad.Post,
                UrlBase = settings.UrlBFF,
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
                UrlBase = settings.UrlBFF, 
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
                UrlBase = settings.UrlBFF,
                Metodo = $"api/Actividad/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new ();
        }

        public async Task<Response<List<ActividadDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.UrlActividad.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<ActividadDto>>>(servicio) ?? new ();
        }

        public async Task<Response<ActividadDto>> BuscarPorIdAsync(int actividad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.UrlActividad.GetPorId}/{actividad}",
                Verbo = Verbo.Get            
            };
            return await ServicioRest.EjecutarServicioAsync<Response<ActividadDto>>(servicio) ?? new Response<ActividadDto>();
        }

        public async Task<Response<List<ActividadDto>>> Buscar(ActividadDto actividad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.UrlActividad.Buscar,
                Verbo = Verbo.Get,
                Parametros = actividad

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<ActividadDto>>>(servicio) ?? new ();
        }
    }
}

using JWork.Administracion.Dto;
using JWork.UI.Administracion.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class TipoPersonaService
    {
        private readonly Settings settings;

        // Constructor
        public TipoPersonaService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<TipoPersonaDto>> CrearAsync(TipoPersonaDto TipoPersona)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoPersona.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Post,
                Parametros = TipoPersona
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoPersonaDto>>(servicio) ?? new Response<TipoPersonaDto>();
        }

        public async Task<Response<TipoPersonaDto>> ModificarAsync(TipoPersonaDto TipoPersona)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoPersona.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Put,
                Parametros = TipoPersona
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoPersonaDto>>(servicio) ?? new Response<TipoPersonaDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"api/TipoPersona/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<TipoPersonaDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.TipoPersona.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoPersonaDto>>>(servicio) ?? new();
        }

        public async Task<Response<TipoPersonaDto>> BuscarPorIdAsync(int TipoPersona)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.TipoPersona.GetPorId}/{TipoPersona}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoPersonaDto>>(servicio) ?? new Response<TipoPersonaDto>();
        }

        public async Task<Response<List<TipoPersonaDto>>> Buscar(TipoPersonaDto TipoPersona)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.TipoPersona.Buscar,
                Verbo = Verbo.Get,
                Parametros = TipoPersona

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoPersonaDto>>>(servicio) ?? new();
        }
    }
}

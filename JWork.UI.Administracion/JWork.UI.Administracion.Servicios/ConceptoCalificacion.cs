using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class ConceptoCalificacionService
    {
        private readonly Settings settings;

        // Constructor
        public ConceptoCalificacionService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<ConceptoCalificacionDto>> CrearAsync(ConceptoCalificacionDto ConceptoCalificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.ConceptoCalificacion.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Post,
                Parametros = ConceptoCalificacion
            };
            return await ServicioRest.EjecutarServicioAsync<Response<ConceptoCalificacionDto>>(servicio) ?? new Response<ConceptoCalificacionDto>();
        }

        public async Task<Response<ConceptoCalificacionDto>> ModificarAsync(ConceptoCalificacionDto ConceptoCalificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.ConceptoCalificacion.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Put,
                Parametros = ConceptoCalificacion
            };
            return await ServicioRest.EjecutarServicioAsync<Response<ConceptoCalificacionDto>>(servicio) ?? new Response<ConceptoCalificacionDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"api/ConceptoCalificacion/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<ConceptoCalificacionDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.ConceptoCalificacion.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<ConceptoCalificacionDto>>>(servicio) ?? new();
        }

        public async Task<Response<ConceptoCalificacionDto>> BuscarPorIdAsync(int ConceptoCalificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.ConceptoCalificacion.GetPorId}/{ConceptoCalificacion}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<ConceptoCalificacionDto>>(servicio) ?? new Response<ConceptoCalificacionDto>();
        }

        public async Task<Response<List<ConceptoCalificacionDto>>> Buscar(ConceptoCalificacionDto ConceptoCalificacion)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.ConceptoCalificacion.Buscar,
                Verbo = Verbo.Get,
                Parametros = ConceptoCalificacion

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<ConceptoCalificacionDto>>>(servicio) ?? new();
        }
    }
}

using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class TipoDocumentoService
    {
        private readonly Settings settings;

        // Constructor
        public TipoDocumentoService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<TipoDocumentoDto>> CrearAsync(TipoDocumentoDto TipoDocumento)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoDocumento.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Post,
                Parametros = TipoDocumento
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoDocumentoDto>>(servicio) ?? new Response<TipoDocumentoDto>();
        }

        public async Task<Response<TipoDocumentoDto>> ModificarAsync(TipoDocumentoDto TipoDocumento)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoDocumento.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Put,
                Parametros = TipoDocumento
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoDocumentoDto>>(servicio) ?? new Response<TipoDocumentoDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"api/TipoDocumento/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<TipoDocumentoDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.TipoDocumento.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoDocumentoDto>>>(servicio) ?? new();
        }

        public async Task<Response<TipoDocumentoDto>> BuscarPorIdAsync(int TipoDocumento)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.TipoDocumento.GetPorId}/{TipoDocumento}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoDocumentoDto>>(servicio) ?? new Response<TipoDocumentoDto>();
        }

        public async Task<Response<List<TipoDocumentoDto>>> Buscar(TipoDocumentoDto TipoDocumento)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.TipoDocumento.Buscar,
                Verbo = Verbo.Get,
                Parametros = TipoDocumento

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoDocumentoDto>>>(servicio) ?? new();
        }
    }
}

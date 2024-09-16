using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class DivipolaService
    {
        private readonly Settings settings;

        // Constructor
        public DivipolaService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<DivipolaDto>> CrearAsync(DivipolaDto Divipola)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Divipola.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Post,
                Parametros = Divipola
            };
            return await ServicioRest.EjecutarServicioAsync<Response<DivipolaDto>>(servicio) ?? new Response<DivipolaDto>();
        }

        public async Task<Response<DivipolaDto>> ModificarAsync(DivipolaDto Divipola)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Divipola.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Put,
                Parametros = Divipola
            };
            return await ServicioRest.EjecutarServicioAsync<Response<DivipolaDto>>(servicio) ?? new Response<DivipolaDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"api/Divipola/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<DivipolaDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.Divipola.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<DivipolaDto>>>(servicio) ?? new();
        }

        public async Task<Response<DivipolaDto>> BuscarPorIdAsync(int Divipola)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.Divipola.GetPorId}/{Divipola}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<DivipolaDto>>(servicio) ?? new Response<DivipolaDto>();
        }

        public async Task<Response<List<DivipolaDto>>> Buscar(DivipolaDto Divipola)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.Divipola.Buscar,
                Verbo = Verbo.Get,
                Parametros = Divipola

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<DivipolaDto>>>(servicio) ?? new();
        }
    }
}

using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class HabilidadService
    {
        private readonly Settings settings;

        // Constructor
        public HabilidadService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<HabilidadDto>> CrearAsync(HabilidadDto Habilidad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Habilidad.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Post,
                Parametros = Habilidad
            };
            return await ServicioRest.EjecutarServicioAsync<Response<HabilidadDto>>(servicio) ?? new Response<HabilidadDto>();
        }

        public async Task<Response<HabilidadDto>> ModificarAsync(HabilidadDto Habilidad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Habilidad.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Put,
                Parametros = Habilidad
            };
            return await ServicioRest.EjecutarServicioAsync<Response<HabilidadDto>>(servicio) ?? new Response<HabilidadDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"api/Habilidad/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<HabilidadDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.Habilidad.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<HabilidadDto>>>(servicio) ?? new();
        }

        public async Task<Response<HabilidadDto>> BuscarPorIdAsync(int Habilidad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.Habilidad.GetPorId}/{Habilidad}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<HabilidadDto>>(servicio) ?? new Response<HabilidadDto>();
        }

        public async Task<Response<List<HabilidadDto>>> Buscar(HabilidadDto Habilidad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.Habilidad.Buscar,
                Verbo = Verbo.Get,
                Parametros = Habilidad

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<HabilidadDto>>>(servicio) ?? new();
        }
    }
}

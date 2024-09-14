using JWork.Administracion.Dto;
using JWork.UI.Administracion.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class OficioService
    {
        private readonly Settings settings;

        // Constructor
        public OficioService(IOptions<Settings> options)
        {
            settings = options.Value ?? throw new ArgumentNullException(nameof(options), "Configuración de 'Settings' no disponible.");
        }

        public async Task<Response<OficioDto>> CrearAsync(OficioDto Oficio)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Oficio.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Post,
                Parametros = Oficio
            };
            return await ServicioRest.EjecutarServicioAsync<Response<OficioDto>>(servicio) ?? new Response<OficioDto>();
        }

        public async Task<Response<OficioDto>> ModificarAsync(OficioDto Oficio)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Oficio.Post,
                UrlBase = settings.UrlBFF,
                Verbo = Verbo.Put,
                Parametros = Oficio
            };
            return await ServicioRest.EjecutarServicioAsync<Response<OficioDto>>(servicio) ?? new Response<OficioDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"api/Oficio/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<OficioDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.Oficio.GetTodo,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<OficioDto>>>(servicio) ?? new();
        }

        public async Task<Response<OficioDto>> BuscarPorIdAsync(int Oficio)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = $"{Constantes.Oficio.GetPorId}/{Oficio}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<OficioDto>>(servicio) ?? new Response<OficioDto>();
        }

        public async Task<Response<List<OficioDto>>> Buscar(OficioDto Oficio)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = settings.UrlBFF,
                Metodo = Constantes.Oficio.Buscar,
                Verbo = Verbo.Get,
                Parametros = Oficio

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<OficioDto>>>(servicio) ?? new();
        }
    }
}

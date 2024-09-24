using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Servicios
{
    public class OficioService
    {

        public async Task<Response<OficioDto>> CrearAsync(OficioDto Oficio)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Oficio.Post,
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.Oficio.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<OficioDto>>>(servicio) ?? new();
        }

        public async Task<Response<OficioDto>> BuscarPorIdAsync(int Oficio)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.Oficio.GetPorIdAsync}/{Oficio}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<OficioDto>>(servicio) ?? new Response<OficioDto>();
        }

        public async Task<Response<List<OficioDto>>> Buscar(OficioDto Oficio)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.Oficio.Buscar,
                Verbo = Verbo.Get,
                Parametros = Oficio

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<OficioDto>>>(servicio) ?? new();
        }
    }
}

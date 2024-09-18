using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class AreaService
    {
        
        public async Task<Response<AreaDto>> CrearAsync(AreaDto Area)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.UrlArea.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Post,
                Parametros = Area
            };
            return await ServicioRest.EjecutarServicioAsync<Response<AreaDto>>(servicio) ?? new Response<AreaDto>();
        }

        public async Task<Response<AreaDto>> ModificarAsync(AreaDto Area)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.UrlArea.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Put,
                Parametros = Area
            };
            return await ServicioRest.EjecutarServicioAsync<Response<AreaDto>>(servicio) ?? new Response<AreaDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"api/Area/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<AreaDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.UrlArea.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<AreaDto>>>(servicio) ?? new();
        }

        public async Task<Response<AreaDto>> BuscarPorIdAsync(int Area)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.UrlArea.GetPorIdAsync}/{Area}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<AreaDto>>(servicio) ?? new Response<AreaDto>();
        }

        public async Task<Response<List<AreaDto>>> Buscar(AreaDto Area)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.UrlArea.Buscar,
                Verbo = Verbo.Get,
                Parametros = Area

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<AreaDto>>>(servicio) ?? new();
        }
    }
}

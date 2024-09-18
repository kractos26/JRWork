using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using Microsoft.Extensions.Options;

namespace JWork.UI.Administracion.Servicios
{
    public class UnidadMedidaService
    {
        

        public async Task<Response<UnidadMedidaDto>> CrearAsync(UnidadMedidaDto UnidadMedida)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.UnidadMedida.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Post,
                Parametros = UnidadMedida
            };
            return await ServicioRest.EjecutarServicioAsync<Response<UnidadMedidaDto>>(servicio) ?? new Response<UnidadMedidaDto>();
        }

        public async Task<Response<UnidadMedidaDto>> ModificarAsync(UnidadMedidaDto UnidadMedida)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.UnidadMedida.Post,
                UrlBase = Constantes.UrlBase,
                Verbo = Verbo.Put,
                Parametros = UnidadMedida
            };
            return await ServicioRest.EjecutarServicioAsync<Response<UnidadMedidaDto>>(servicio) ?? new Response<UnidadMedidaDto>();
        }

        public async Task<Response<bool>> EliminarAsync(int id)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"api/UnidadMedida/Eliminar/{id}",
                Verbo = Verbo.Delete
            };
            return await ServicioRest.EjecutarServicioAsync<Response<bool>>(servicio) ?? new();
        }

        public async Task<Response<List<UnidadMedidaDto>>> BuscarTodoAsync()
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.UnidadMedida.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<UnidadMedidaDto>>>(servicio) ?? new();
        }

        public async Task<Response<UnidadMedidaDto>> BuscarPorIdAsync(int UnidadMedida)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.UnidadMedida.GetPorIdAsync}/{UnidadMedida}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<UnidadMedidaDto>>(servicio) ?? new Response<UnidadMedidaDto>();
        }

        public async Task<Response<List<UnidadMedidaDto>>> Buscar(UnidadMedidaDto UnidadMedida)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.UnidadMedida.Buscar,
                Verbo = Verbo.Get,
                Parametros = UnidadMedida

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<UnidadMedidaDto>>>(servicio) ?? new();
        }
    }
}

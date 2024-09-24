using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Servicios
{
    public class TipoDocumentoService
    {


        public async Task<Response<TipoDocumentoDto>> CrearAsync(TipoDocumentoDto TipoDocumento)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoDocumento.Post,
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.TipoDocumento.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoDocumentoDto>>>(servicio) ?? new();
        }

        public async Task<Response<TipoDocumentoDto>> BuscarPorIdAsync(int TipoDocumento)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.TipoDocumento.GetPorIdAsync}/{TipoDocumento}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoDocumentoDto>>(servicio) ?? new Response<TipoDocumentoDto>();
        }

        public async Task<Response<List<TipoDocumentoDto>>> Buscar(TipoDocumentoDto TipoDocumento)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.TipoDocumento.Buscar,
                Verbo = Verbo.Get,
                Parametros = TipoDocumento

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoDocumentoDto>>>(servicio) ?? new();
        }
    }
}

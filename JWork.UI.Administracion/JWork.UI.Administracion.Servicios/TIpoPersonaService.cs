using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Servicios
{
    public class TipoPersonaService
    {


        public async Task<Response<TipoPersonaDto>> CrearAsync(TipoPersonaDto TipoPersona)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.TipoPersona.Post,
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.TipoPersona.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoPersonaDto>>>(servicio) ?? new();
        }

        public async Task<Response<TipoPersonaDto>> BuscarPorIdAsync(int TipoPersona)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.TipoPersona.GetPorIdAsync}/{TipoPersona}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<TipoPersonaDto>>(servicio) ?? new Response<TipoPersonaDto>();
        }

        public async Task<Response<List<TipoPersonaDto>>> Buscar(TipoPersonaDto TipoPersona)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.TipoPersona.Buscar,
                Verbo = Verbo.Get,
                Parametros = TipoPersona

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<TipoPersonaDto>>>(servicio) ?? new();
        }
    }
}

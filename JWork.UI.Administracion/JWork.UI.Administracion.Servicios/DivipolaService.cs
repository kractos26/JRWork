using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Servicios
{
    public class DivipolaService
    {

        public async Task<Response<DivipolaDto>> CrearAsync(DivipolaDto Divipola)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Divipola.Post,
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.Divipola.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<DivipolaDto>>>(servicio) ?? new();
        }

        public async Task<Response<DivipolaDto>> BuscarPorIdAsync(int Divipola)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.Divipola.GetPorIdAsync}/{Divipola}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<DivipolaDto>>(servicio) ?? new Response<DivipolaDto>();
        }

        public async Task<Response<List<DivipolaDto>>> Buscar(DivipolaDto Divipola)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.Divipola.Buscar,
                Verbo = Verbo.Get,
                Parametros = Divipola

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<DivipolaDto>>>(servicio) ?? new();
        }
    }
}

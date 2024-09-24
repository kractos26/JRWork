using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Servicios
{
    public class HabilidadService
    {


        public async Task<Response<HabilidadDto>> CrearAsync(HabilidadDto Habilidad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                Metodo = Constantes.Habilidad.Post,
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
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
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.Habilidad.GetTodoAsync,
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<HabilidadDto>>>(servicio) ?? new();
        }

        public async Task<Response<HabilidadDto>> BuscarPorIdAsync(int Habilidad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = $"{Constantes.Habilidad.GetPorIdAsync}/{Habilidad}",
                Verbo = Verbo.Get
            };
            return await ServicioRest.EjecutarServicioAsync<Response<HabilidadDto>>(servicio) ?? new Response<HabilidadDto>();
        }

        public async Task<Response<List<HabilidadDto>>> Buscar(HabilidadDto Habilidad)
        {
            ParametrosServicio servicio = new()
            {
                Encabezado = null,
                UrlBase = Constantes.UrlBase,
                Metodo = Constantes.Habilidad.Buscar,
                Verbo = Verbo.Get,
                Parametros = Habilidad

            };
            return await ServicioRest.EjecutarServicioAsync<Response<List<HabilidadDto>>>(servicio) ?? new();
        }
    }
}

using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class TipoPersonaBL
    {
        private readonly TipoPersonaService _service;
        public TipoPersonaBL(TipoPersonaService service)
        {
            _service = service; 
        }

        public async Task<Response<TipoPersonaDto>> Crear(TipoPersonaDto request) => await _service.CrearAsync(request);
        public async Task<Response<TipoPersonaDto>> Modificar(TipoPersonaDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<TipoPersonaDto>>> GetTodoAsync() => await _service.BuscarTodoAsync();
        public async Task<Response<TipoPersonaDto>> GetPorIdAsync(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<TipoPersonaDto>>> Buscar(TipoPersonaDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

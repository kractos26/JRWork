using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class TipoIdentificacionBL
    {
        private readonly TipoIdentificacionService _service;
        public TipoIdentificacionBL(TipoIdentificacionService service)
        {
            _service = service; 
        }

        public async Task<Response<TipoIdentificacionDto>> Crear(TipoIdentificacionDto request) => await _service.CrearAsync(request);
        public async Task<Response<TipoIdentificacionDto>> Modificar(TipoIdentificacionDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<TipoIdentificacionDto>>> GetTodoAsync() => await _service.BuscarTodoAsync();
        public async Task<Response<TipoIdentificacionDto>> GetPorIdAsync(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<TipoIdentificacionDto>>> Buscar(TipoIdentificacionDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

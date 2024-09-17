using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class OficioBL
    {
        private readonly OficioService _service;
        public OficioBL(OficioService service)
        {
            _service = service; 
        }

        public async Task<Response<OficioDto>> Crear(OficioDto request) => await _service.CrearAsync(request);
        public async Task<Response<OficioDto>> Modificar(OficioDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<OficioDto>>> GetTodo() => await _service.BuscarTodoAsync();
        public async Task<Response<OficioDto>> GetPorId(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<OficioDto>>> Buscar(OficioDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

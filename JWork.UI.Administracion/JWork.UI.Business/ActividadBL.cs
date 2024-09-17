using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class ActividadBL
    {
        private readonly ActividadService _service;
        public ActividadBL(ActividadService service)
        {
            _service = service; 
        }

        public async Task<Response<ActividadDto>> Crear(ActividadDto request) => await _service.CrearAsync(request);
        public async Task<Response<ActividadDto>> Modificar(ActividadDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<ActividadDto>>> GetTodo() => await _service.BuscarTodoAsync();
        public async Task<Response<ActividadDto>> GetPorId(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<ActividadDto>>> Buscar(ActividadDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

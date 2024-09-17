using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class DivipolaBL
    {
        private readonly DivipolaService _service;
        public DivipolaBL(DivipolaService service)
        {
            _service = service; 
        }

        public async Task<Response<DivipolaDto>> Crear(DivipolaDto request) => await _service.CrearAsync(request);
        public async Task<Response<DivipolaDto>> Modificar(DivipolaDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<DivipolaDto>>> GetTodo() => await _service.BuscarTodoAsync();
        public async Task<Response<DivipolaDto>> GetPorId(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<DivipolaDto>>> Buscar(DivipolaDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

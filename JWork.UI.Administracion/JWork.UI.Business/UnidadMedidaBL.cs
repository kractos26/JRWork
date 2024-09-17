using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class UnidadMedidaBL
    {
        private readonly UnidadMedidaService _service;
        public UnidadMedidaBL(UnidadMedidaService service)
        {
            _service = service; 
        }

        public async Task<Response<UnidadMedidaDto>> Crear(UnidadMedidaDto request) => await _service.CrearAsync(request);
        public async Task<Response<UnidadMedidaDto>> Modificar(UnidadMedidaDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<UnidadMedidaDto>>> GetTodo() => await _service.BuscarTodoAsync();
        public async Task<Response<UnidadMedidaDto>> GetPorId(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<UnidadMedidaDto>>> Buscar(UnidadMedidaDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

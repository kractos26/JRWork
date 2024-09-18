using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class AreaBL
    {
        private readonly AreaService _service;
        public AreaBL(AreaService service)
        {
            _service = service; 
        }

        public async Task<Response<AreaDto>> Crear(AreaDto area) => await _service.CrearAsync(area);
        public async Task<Response<AreaDto>> Modificar(AreaDto area) => await _service.ModificarAsync(area);
        public async Task<Response<List<AreaDto>>> GetTodoAsync() => await _service.BuscarTodoAsync();
        public async Task<Response<List<AreaDto>>> Buscar(AreaDto request) => await _service.Buscar(request);
        public async Task<Response<AreaDto>> GetPorIdAsync(int id) => await _service.BuscarPorIdAsync(id);

    }
}

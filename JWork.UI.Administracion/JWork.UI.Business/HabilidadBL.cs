using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class HabilidadBL
    {
        private readonly HabilidadService _service;
        public HabilidadBL(HabilidadService service)
        {
            _service = service; 
        }

        public async Task<Response<HabilidadDto>> Crear(HabilidadDto request) => await _service.CrearAsync(request);
        public async Task<Response<HabilidadDto>> Modificar(HabilidadDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<HabilidadDto>>> GetTodoAsync() => await _service.BuscarTodoAsync();
        public async Task<Response<HabilidadDto>> GetPorIdAsync(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<HabilidadDto>>> Buscar(HabilidadDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

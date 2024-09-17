using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class TipoDocumentoBL
    {
        private readonly TipoDocumentoService _service;
        public TipoDocumentoBL(TipoDocumentoService service)
        {
            _service = service; 
        }

        public async Task<Response<TipoDocumentoDto>> Crear(TipoDocumentoDto request) => await _service.CrearAsync(request);
        public async Task<Response<TipoDocumentoDto>> Modificar(TipoDocumentoDto request) => await _service.ModificarAsync(request);
        public async Task<Response<List<TipoDocumentoDto>>> GetTodo() => await _service.BuscarTodoAsync();
        public async Task<Response<TipoDocumentoDto>> GetPorId(int id) => await _service.BuscarPorIdAsync(id);
        public async Task<Response<List<TipoDocumentoDto>>> Buscar(TipoDocumentoDto request) => await _service.Buscar(request);
        public async Task<Response<bool>> Eliminar(int id) => await _service.EliminarAsync(id);


    }
}

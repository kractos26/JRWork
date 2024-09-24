using AutoMapper;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class TipoDocumentoBL(IRepositoryTipoDocumento repository, IMapper mapper)
    {
        private readonly IRepositoryTipoDocumento _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<TipoDocumentoDto> Crear(TipoDocumentoDto request)
        {
            TipoDocumento entidad = _mapper.Map<TipoDocumento>(request);
            if (request.Nombre == null)
            {
                throw new JWorkException("El tipo de documento ya se encuentra creada");
            }


            TipoDocumento? exist = await _repository.TraerUnoAsync(x => x.Nombre.Equals(request.Nombre, StringComparison.CurrentCultureIgnoreCase));
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkException("EL Tipo de documento ya se encuentra creada");
            }
            return _mapper.Map<TipoDocumentoDto>(entidad);
        }

        public async Task<TipoDocumentoDto> Modificar(TipoDocumentoDto request)
        {
            string mensaje = "El concepto de calificación no existe";

            if (request.TipoDocumentoId <= 0)
            {
                throw new JWorkException(mensaje);
            }
            if (request.Nombre == null)
            {
                throw new JWorkException("EL tipo de documento ya se encuentra creada");
            }

            TipoDocumento? entidad = await _repository.TraerUnoAsync(x => x.TipoDocumentoId == request.TipoDocumentoId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<TipoDocumentoDto>(entidad);
        }

        public async Task<List<TipoDocumentoDto>> Buscar(PaginadoRequest<TipoDocumentoDto> request)
        {
            List<TipoDocumento> buscar = await _repository.BuscarPaginadoAsync(x => request.Entidad != null && x.TipoDocumentoId == (request.Entidad.TipoDocumentoId > 0 ? request.Entidad.TipoDocumentoId : x.TipoDocumentoId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count > 0)
            {
                return _mapper.Map<List<TipoDocumentoDto>>(buscar);
            }
            throw new JWorkException("Registros no encontrados");

        }

        public async Task<TipoDocumentoDto> GetPorIdAsync(int actividadId)
        {
            TipoDocumento? actividad = await _repository.TraerUnoAsync(x => x.TipoDocumentoId == actividadId);
            return _mapper.Map<TipoDocumentoDto>(actividad);
        }
    }
}

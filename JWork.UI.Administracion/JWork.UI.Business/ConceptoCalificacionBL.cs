using AutoMapper;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class ConceptoCalificacionBL(IRepositoryConceptoCalificacion repository, IMapper mapper)
    {
        private readonly IRepositoryConceptoCalificacion _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<ConceptoCalificacionDto> Crear(ConceptoCalificacionDto request)
        {
            ConceptoCalificacion entidad = _mapper.Map<ConceptoCalificacion>(request);
            if (request.Nombre == null)
            {
                throw new JWorkException("Ingresa la concepto de calificación");
            }


            ConceptoCalificacion? exist = await _repository.TraerUnoAsync(x => x.Nombre.Equals(request.Nombre, StringComparison.CurrentCultureIgnoreCase));
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkException("EL concepto de calificación ya se encuentra creado");
            }
            return _mapper.Map<ConceptoCalificacionDto>(entidad);
        }

        public async Task<ConceptoCalificacionDto> Modificar(ConceptoCalificacionDto request)
        {
            string mensaje = "El concepto de calificación no existe";

            if (request.ConceptoCalificacionId <= 0)
            {
                throw new JWorkException(mensaje);
            }
            ConceptoCalificacion? entidad = await _repository.TraerUnoAsync(x => x.ConceptoCalificacionId == request.ConceptoCalificacionId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<ConceptoCalificacionDto>(entidad);
        }


        public async Task<List<ConceptoCalificacionDto>> Buscar(PaginadoRequest<ConceptoCalificacionDto> request)
        {
            List<ConceptoCalificacion> buscar = await _repository.BuscarPaginadoAsync(x => request.Entidad != null && x.ConceptoCalificacionId == (request.Entidad.ConceptoCalificacionId > 0 ? request.Entidad.ConceptoCalificacionId : x.ConceptoCalificacionId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count > 0)
            {
                return _mapper.Map<List<ConceptoCalificacionDto>>(buscar);
            }
            throw new JWorkException("Registros no encontrados");

        }

        public async Task<ConceptoCalificacionDto> GetPorIdAsync(int actividadId)
        {
            ConceptoCalificacion? actividad = await _repository.TraerUnoAsync(x => x.ConceptoCalificacionId == actividadId);
            return _mapper.Map<ConceptoCalificacionDto>(actividad);
        }
    }
}

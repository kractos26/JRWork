using AutoMapper;
using JRWork.UI.Administracion.DataAccess.Models;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class TipoIdentificacionBL
    {
        private readonly IRepositoryTipoIdentificacion _repository;
        private readonly IMapper _mapper;
        public TipoIdentificacionBL(IRepositoryTipoIdentificacion repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TipoIdentificacionDto> Crear(TipoIdentificacionDto request)
        {
            TipoIdentificacion entidad = _mapper.Map<TipoIdentificacion>(request);
            if (request.Nombre == null)
            {
                throw new JWorkExecectioncs("El tipo de identificación ya se encuentra creado");
            }


            TipoIdentificacion? exist = await _repository.TraerUnoAsync(x => x.Nombre.ToLower() == request.Nombre.ToLower());
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkExecectioncs("EL Tipo de identificación ya se encuentra creado");
            }
            return _mapper.Map<TipoIdentificacionDto>(entidad);
        }

        public async Task<TipoIdentificacionDto> Modificar(TipoIdentificacionDto request)
        {
            string mensaje = "El concepto de calificación no existe";

            if (request.TipoIdentificacionId <= 0)
            {
                throw new JWorkExecectioncs(mensaje);
            }
            if (request.Nombre == null)
            {
                throw new JWorkExecectioncs("EL tipo de identificación ya se encuentra creado");
            }

            TipoIdentificacion? entidad = await _repository.TraerUnoAsync(x => x.TipoIdentificacionId == request.TipoIdentificacionId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<TipoIdentificacionDto>(entidad);
        }

        public async Task<List<TipoIdentificacionDto>> Buscar(PaginadoRequest<TipoIdentificacionDto> request)
        {
            List<TipoIdentificacion> buscar = await _repository.BuscarPaginadoAsync(x => request.Entidad != null && x.TipoIdentificacionId == (request.Entidad.TipoIdentificacionId > 0 ? request.Entidad.TipoIdentificacionId : x.TipoIdentificacionId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count() > 0)
            {
                return _mapper.Map<List<TipoIdentificacionDto>>(buscar);
            }
            throw new JWorkExecectioncs("Registros no encontrados");

        }

        public async Task<TipoIdentificacionDto> GetPorIdAsync(int actividadId)
        {
            TipoIdentificacion? actividad = await _repository.TraerUnoAsync(x => x.TipoIdentificacionId == actividadId);
            return _mapper.Map<TipoIdentificacionDto>(actividad);
        }
    }
}

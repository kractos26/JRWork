using AutoMapper;
using JRWork.UI.Administracion.DataAccess.Models;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class TipoPersonaBL
    {
        private readonly IRepositoryTipoPersona _repository;
        private readonly IMapper _mapper;
        public TipoPersonaBL(IRepositoryTipoPersona repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TipoPersonaDto> Crear(TipoPersonaDto request)
        {
            TipoPersona entidad = _mapper.Map<TipoPersona>(request);
            if (request.Nombre == null)
            {
                throw new JWorkExecectioncs("El tipo de persona ya se encuentra creado");
            }


            TipoPersona? exist = await _repository.TraerUnoAsync(x => x.Nombre.ToLower() == request.Nombre.ToLower());
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkExecectioncs("EL tipo de persona ya se encuentra creado");
            }
            return _mapper.Map<TipoPersonaDto>(entidad);
        }

        public async Task<TipoPersonaDto> Modificar(TipoPersonaDto request)
        {
            string mensaje = "El tipo de persona no existe";

            if (request.TipoPersonaId <= 0)
            {
                throw new JWorkExecectioncs(mensaje);
            }
            if (request.Nombre == null)
            {
                throw new JWorkExecectioncs("EL tipo de persona ya se encuentra creado");
            }

            TipoPersona? entidad = await _repository.TraerUnoAsync(x => x.TipoPersonaId == request.TipoPersonaId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<TipoPersonaDto>(entidad);
        }

        public async Task<List<TipoPersonaDto>> Buscar(PaginadoRequest<TipoPersonaDto> request)
        {
            List<TipoPersona> buscar = await _repository.BuscarPaginadoAsync(x =>request.Entidad != null && x.TipoPersonaId == (request.Entidad.TipoPersonaId > 0 ? request.Entidad.TipoPersonaId : x.TipoPersonaId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count() > 0)
            {
                return _mapper.Map<List<TipoPersonaDto>>(buscar);
            }
            throw new JWorkExecectioncs("Registros no encontrados");

        }

        public async Task<TipoPersonaDto> GetPorIdAsync(int actividadId)
        {
            TipoPersona? actividad = await _repository.TraerUnoAsync(x => x.TipoPersonaId == actividadId);
            return _mapper.Map<TipoPersonaDto>(actividad);
        }
    }
}

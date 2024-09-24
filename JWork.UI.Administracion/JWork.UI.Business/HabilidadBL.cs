using AutoMapper;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class HabilidadBL(IRepositoryHabilidad repository, IMapper mapper)
    {
        private readonly IRepositoryHabilidad _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<HabilidadDto> Crear(HabilidadDto request)
        {
            Habilidad entidad = _mapper.Map<Habilidad>(request);
            if (request.Nombre == null)
            {
                throw new JWorkException("La habilidad ya se encuentra creada");
            }
            if (request.ActividadId == 0)
            {
                throw new JWorkException("Elija la actividad a la cual va a pertenecer la habidad");

            }

            Habilidad? exist = await _repository.TraerUnoAsync(x => x.Nombre.Equals(request.Nombre, StringComparison.CurrentCultureIgnoreCase));
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkException("La habilidad ya se encuentra creada");
            }
            return _mapper.Map<HabilidadDto>(entidad);
        }

        public async Task<HabilidadDto> Modificar(HabilidadDto request)
        {
            string mensaje = "El concepto de calificación no existe";

            if (request.HabilidadId <= 0)
            {
                throw new JWorkException(mensaje);
            }
            if (request.Nombre == null)
            {
                throw new JWorkException("La habilidad ya se encuentra creada");
            }
            if (request.ActividadId == 0)
            {
                throw new JWorkException("Elija la actividad a la cual va a pertenecer la habidad");

            }
            Habilidad? entidad = await _repository.TraerUnoAsync(x => x.HabilidadId == request.HabilidadId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<HabilidadDto>(entidad);
        }


        public async Task<List<HabilidadDto>> Buscar(PaginadoRequest<HabilidadDto> request)
        {
            List<Habilidad> buscar = await _repository.BuscarPaginadoAsync(x => request.Entidad != null && x.HabilidadId == (request.Entidad.HabilidadId > 0 ? request.Entidad.HabilidadId : x.HabilidadId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre) && x.ActividadId == (request.Entidad.ActividadId > 0 ? request.Entidad.ActividadId : x.ActividadId), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count > 0)
            {
                return _mapper.Map<List<HabilidadDto>>(buscar);
            }
            throw new JWorkException("Registros no encontrados");

        }

        public async Task<HabilidadDto> GetPorIdAsync(int actividadId)
        {
            Habilidad? actividad = await _repository.TraerUnoAsync(x => x.HabilidadId == actividadId);
            return _mapper.Map<HabilidadDto>(actividad);
        }
    }
}

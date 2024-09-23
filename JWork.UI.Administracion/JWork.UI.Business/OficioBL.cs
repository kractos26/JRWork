using AutoMapper;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class OficioBL(
        IRepositoryOficio repository, IMapper mapper)
    {
        private readonly IRepositoryOficio _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<OficioDto> Crear(OficioDto request)
        {
            Oficio entidad = _mapper.Map<Oficio>(request);
            if (request.Nombre == null)
            {
                throw new JWorkException("El Oficio ya se encuentra creada");
            }
            if (request.AreaId == 0)
            {
                throw new JWorkException("Elija el área donde pertenece el oficio");

            }

            Oficio? exist = await _repository.TraerUnoAsync(x =>  x.Nombre.Equals(request.Nombre, StringComparison.CurrentCultureIgnoreCase));
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkException("EL Oficio ya se encuentra creada");
            }
            return _mapper.Map<OficioDto>(entidad);
        }

        public async Task<OficioDto> Modificar(OficioDto request)
        {
            string mensaje = "El concepto de calificación no existe";

            if (request.OficioId <= 0)
            {
                throw new JWorkException(mensaje);
            }
            if (request.Nombre == null)
            {
                throw new JWorkException("La Oficio ya se encuentra creada");
            }
            if (request.AreaId == 0)
            {
                throw new JWorkException("Elija un área a la cual va a pertenecer el oficio");

            }
            Oficio? entidad = await _repository.TraerUnoAsync(x => x.OficioId == request.OficioId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<OficioDto>(entidad);
        }

        public async Task<List<OficioDto>> Buscar(PaginadoRequest<OficioDto> request)
        {
            List<Oficio> buscar = await _repository.BuscarPaginadoAsync(x => request.Entidad != null && x.OficioId == (request.Entidad.OficioId > 0 ? request.Entidad.OficioId : x.OficioId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre) && x.AreaId == (request.Entidad.AreaId > 0 ? request.Entidad.AreaId : x.AreaId), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count > 0)
            {
                return _mapper.Map<List<OficioDto>>(buscar);
            }
            throw new JWorkException("Registros no encontrados");

        }

        public async Task<OficioDto> GetPorIdAsync(int actividadId)
        {
            Oficio? actividad = await _repository.TraerUnoAsync(x => x.OficioId == actividadId);
            return _mapper.Map<OficioDto>(actividad);
        }
    }
}

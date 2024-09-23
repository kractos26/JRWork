using AutoMapper;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class UnidadMedidaBL(IRepositoryUnidadMedida repository, IMapper mapper)
    {
        private readonly IRepositoryUnidadMedida _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<UnidadMedidaDto> Crear(UnidadMedidaDto request)
        {
            UnidadMedida entidad = _mapper.Map<UnidadMedida>(request);
            if (request.Nombre == null)
            {
                throw new JWorkException("El tipo de persona ya se encuentra creado");
            }


            UnidadMedida? exist = await _repository.TraerUnoAsync(x => x.Nombre.Equals(request.Nombre, StringComparison.OrdinalIgnoreCase));
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkException("EL tipo de persona ya se encuentra creado");
            }
            return _mapper.Map<UnidadMedidaDto>(entidad);
        }

        public async Task<UnidadMedidaDto> Modificar(UnidadMedidaDto request)
        {
            string mensaje = "El tipo de persona no existe";

            if (request.UnidadMedidaId <= 0)
            {
                throw new JWorkException(mensaje);
            }
            if (request.Nombre == null)
            {
                throw new JWorkException("EL tipo de persona ya se encuentra creado");
            }

            UnidadMedida? entidad = await _repository.TraerUnoAsync(x => x.UnidadMedidaId == request.UnidadMedidaId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<UnidadMedidaDto>(entidad);
        }

        public async Task<List<UnidadMedidaDto>> Buscar(PaginadoRequest<UnidadMedidaDto> request)
        {
            List<UnidadMedida> buscar = await _repository.BuscarPaginadoAsync(x => request.Entidad != null && x.UnidadMedidaId == (request.Entidad.UnidadMedidaId > 0 ? request.Entidad.UnidadMedidaId : x.UnidadMedidaId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count > 0)
            {
                return _mapper.Map<List<UnidadMedidaDto>>(buscar);
            }
            throw new JWorkException("Registros no encontrados");

        }

        public async Task<UnidadMedidaDto> GetPorIdAsync(int actividadId)
        {
            UnidadMedida? actividad = await _repository.TraerUnoAsync(x => x.UnidadMedidaId == actividadId);
            return _mapper.Map<UnidadMedidaDto>(actividad);
        }

    }
}

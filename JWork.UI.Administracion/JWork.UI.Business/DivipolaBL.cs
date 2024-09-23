using AutoMapper;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Servicios;

namespace JWork.UI.Administracion.Business
{
    public class DivipolaBL
    {
        private readonly IRepositoryDivipola _repository;
        private readonly IMapper _mapper;
        public DivipolaBL(IRepositoryDivipola repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DivipolaDto> Crear(DivipolaDto request)
        {
            Divipola entidad = _mapper.Map<Divipola>(request);
            if (request.Nombre == null)
            {
                throw new Exception("La división politica ya se encuentra creada");
            }


            Divipola? exist = await _repository.TraerUnoAsync(x => x.Nombre.ToLower() == request.Nombre.ToLower());
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new Exception("La división politica ya se encuentra creada");
            }
            return _mapper.Map<DivipolaDto>(entidad);
        }

        public async Task<DivipolaDto> Modificar(DivipolaDto request)
        {
            string mensaje = "El concepto de calificación no existe";

            if (request.DivipolaId <= 0)
            {
                throw new Exception(mensaje);
            }
            Divipola? entidad = await _repository.TraerUnoAsync(x => x.DivipolaId == request.DivipolaId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<DivipolaDto>(entidad);
        }


        public async Task<List<DivipolaDto>> Buscar(PaginadoRequest<DivipolaDto> request)
        {
            List<Divipola> buscar = await _repository.BuscarPaginadoAsync(x => request.Entidad != null && x.DivipolaId == (request.Entidad.DivipolaId > 0 ? request.Entidad.DivipolaId : x.DivipolaId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre) && x.CodigoPadre == (request.Entidad.CodigoPadre ?? x.CodigoPadre), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count > 0)
            {
                return _mapper.Map<List<DivipolaDto>>(buscar);
            }
            throw new NotImplementedException("Registros no encontrados");

        }

        public async Task<DivipolaDto> GetPorIdAsync(int actividadId)
        {
            Divipola? actividad = await _repository.TraerUnoAsync(x => x.DivipolaId == actividadId);
            return _mapper.Map<DivipolaDto>(actividad);
        }
    }
}

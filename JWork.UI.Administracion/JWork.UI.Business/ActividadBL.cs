using AutoMapper;
using JRWork.UI.Administracion.DataAccess.Models;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;


namespace JWork.UI.Administracion.Business
{
    public class ActividadBL
    {
        private readonly IRepositoryActividad _repository;
        private readonly IMapper _mapper;
        public ActividadBL(IRepositoryActividad repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActividadDto> Crear(ActividadDto request)
        {
            Actividad entidad = _mapper.Map<Actividad>(request);
            if (request.Nombre == null)
            {
                throw new JWorkExecectioncs("Ingresa la actividad");
            }
            if (request.OficioId == 0)
            {
                throw new JWorkExecectioncs("La activiad debe ir relacionada a un oficio");
            }

            Actividad? exist = await _repository.TraerUnoAsync(x => x.Nombre.ToLower() == request.Nombre.ToLower());
            if (exist == null)
            {
                await _repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkExecectioncs("La actividad ya se encuentra creada");
            }
            return _mapper.Map<ActividadDto>(entidad);
        }

        public async Task<ActividadDto> Modificar(ActividadDto request)
        {
            string mensaje = "La actividad no existe";

            if (request.ActividadId <= 0)
            {
                throw new JWorkExecectioncs(mensaje);
            }
            Actividad? entidad = await _repository.TraerUnoAsync(x => x.ActividadId == request.ActividadId);
            if (entidad != null)
            {
                _mapper.Map(request, entidad);
                await _repository.ModificarAsync(entidad);
            }
            return _mapper.Map<ActividadDto>(entidad);
        }


        public async Task<List<ActividadDto>> Buscar(PaginadoRequest<ActividadDto> request)
        {
            List<Actividad> buscar = await _repository.BuscarPaginadoAsync(x=>x.ActividadId == (request.Entidad.ActividadId ?? x.ActividadId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre) && x.OficioId == (request.Entidad.OficioId ?? x.OficioId) , request.NumeroPagina,request.TotalRegistros);
            if(buscar.Count() > 0)
            {
                return _mapper.Map<List<ActividadDto>>(buscar);
            }
            throw new JWorkExecectioncs("Registros no encontrados");
            
        }

        public async Task<ActividadDto> GetPorIdAsync(int actividadId)
        {
            Actividad? actividad = await  _repository.TraerUnoAsync(x=>x.ActividadId==actividadId);
            return _mapper.Map<ActividadDto>(actividad);
        }
    }
}

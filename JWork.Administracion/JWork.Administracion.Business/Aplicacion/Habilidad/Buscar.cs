using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Habilidad;

public class Buscar
{

    public class HabilidadBuscarCommand : IRequest<List<HabilidadDto>>
    {
        public int? HabilidadId { get; set; }

        public string? Nombre { get; set; }

        public int? ActividadId { get; set; }

       
    }

    public class HabilidadBuscarPaginadoCommand : IRequest<List<HabilidadDto>>
    {
        public string? Nombre { get; set; }

        public int? ActividadId { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }

    public class HabilidadBuscarTodoCommand : IRequest<List<HabilidadDto>>
    {

    }

    public class HabilidadBuscarIdCommand : IRequest<HabilidadDto>
    {
        public int HabilidadId { get; set; }
    }

    public class HabilidadRegisterHandler : IRequestHandler<HabilidadBuscarCommand, List<HabilidadDto>>,
                                            IRequestHandler<HabilidadBuscarTodoCommand, List<HabilidadDto>>,
                                            IRequestHandler<HabilidadBuscarIdCommand, HabilidadDto>,
        IRequestHandler<HabilidadBuscarPaginadoCommand, List<HabilidadDto>>
    {
        private readonly IRepositoryHabilidad _repositoryHabilidad;
        private readonly IMapper _mapper;

        public HabilidadRegisterHandler(IRepositoryHabilidad repositoryHabilidad, IMapper mapper)
        {
            _repositoryHabilidad = repositoryHabilidad;
            _mapper = mapper;
        }

        public async Task<List<HabilidadDto>> Handle(HabilidadBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Habilidad> Habilidades = await _repositoryHabilidad.BuscarAsync(x=>x.HabilidadId == (request.HabilidadId ?? x.HabilidadId) && x.ActividadId == (request.ActividadId ?? x.ActividadId) && x.Nombre == (request.Nombre ?? x.Nombre));
            return _mapper.Map<List<HabilidadDto>>(Habilidades);

        }

        public async Task<List<HabilidadDto>> Handle(HabilidadBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Habilidad> Habilidades = await _repositoryHabilidad.GetAllAsync();
            return _mapper.Map<List<HabilidadDto>>(Habilidades);
        }

        public async Task<HabilidadDto> Handle(HabilidadBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var Habilidades = await _repositoryHabilidad.TraerUnoAsync(x=>x.HabilidadId == request.HabilidadId);
            return _mapper.Map<HabilidadDto>(Habilidades);
        }

        public async Task<List<HabilidadDto>> Handle(HabilidadBuscarPaginadoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Habilidad> Habilidades = await _repositoryHabilidad.BuscarPaginadoAsync(x => x.ActividadId == (request.ActividadId ?? x.ActividadId) && x.Nombre == (request.Nombre ?? x.Nombre),request.NumeroPagina,request.TamanoPagina);
            return _mapper.Map<List<HabilidadDto>>(Habilidades);
        }
    }

}
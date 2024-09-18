using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Actividad;

public class Buscar
{
    public class ActividadBuscarPaginadoCommand : IRequest<List<ActividadDto>>
    {
        public int? ActividadId { get; set; }
        public string? Nombre { get; set; } = null!;
        public int? OficioId { get; set; }

        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }

    public class ActividadBuscarCommand : IRequest<List<ActividadDto>>
    {
        public int? ActividadId { get; set; }
        public string? Nombre { get; set; } = null!;
        public int? OficioId { get; set; }
    }

    public class ActividadBuscarTodoCommand : IRequest<List<ActividadDto>>
    {

    }

    public class ActividadBuscarIdCommand : IRequest<ActividadDto>
    {
        public int ActividadId { get; set; }
    }



    public class ActividadRegisterHandler : IRequestHandler<ActividadBuscarCommand, List<ActividadDto>>,
                                            IRequestHandler<ActividadBuscarTodoCommand, List<ActividadDto>>,
                                            IRequestHandler<ActividadBuscarIdCommand, ActividadDto>,
                                            IRequestHandler<ActividadBuscarPaginadoCommand, List<ActividadDto>>
    {
        private readonly IRepositoryActividad _repositoryActividad;
        private readonly IMapper _mapper;

        public ActividadRegisterHandler(IRepositoryActividad repositoryActividad, IMapper mapper)
        {
            _repositoryActividad = repositoryActividad;
            _mapper = mapper;
        }

        public async Task<List<ActividadDto>> Handle(ActividadBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Actividad> actividades = await _repositoryActividad.BuscarAsync(x => x.ActividadId == (request.ActividadId ?? x.ActividadId) && x.OficioId == (request.OficioId ?? x.OficioId) && x.Nombre == (request.Nombre ?? x.Nombre));
            return _mapper.Map<List<ActividadDto>>(actividades);

        }

        public async Task<List<ActividadDto>> Handle(ActividadBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Actividad> actividades = await _repositoryActividad.GetAllAsync();
            return _mapper.Map<List<ActividadDto>>(actividades);
        }

        public async Task<ActividadDto> Handle(ActividadBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var actividades = await _repositoryActividad.TraerUnoAsync(x => x.ActividadId == request.ActividadId);
            return _mapper.Map<ActividadDto>(actividades);
        }

        public async Task<List<ActividadDto>> Handle(ActividadBuscarPaginadoCommand request, CancellationToken cancellationToken)
        {
            var actividadesPaginadas = await _repositoryActividad.BuscarPaginadoAsync(
            x => x.ActividadId == (request.ActividadId ?? x.ActividadId) &&
                 x.OficioId == (request.OficioId ?? x.OficioId) &&
                 x.Nombre == (request.Nombre ?? x.Nombre),
            request.NumeroPagina,
            request.TamanoPagina
        );

            return _mapper.Map<List<ActividadDto>>(actividadesPaginadas);
        }
    }

}
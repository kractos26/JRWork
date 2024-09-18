using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.ConceptoCalificacion;

public class Buscar
{

    public class ConceptoCalificacionBuscarCommand : IRequest<List<ConceptoCalificacionDto>>
    {
        public int? ConceptoCalificacionId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }
    }

    public class ConceptoCalificacionBuscarTodoCommand : IRequest<List<ConceptoCalificacionDto>>
    {

    }

    public class ConceptoCalificacionBuscarIdCommand : IRequest<ConceptoCalificacionDto>
    {
        public int ConceptoCalificacionId { get; set; }
    }

    public class ConceptoCalificacionPaginadoBuscarCommand : IRequest<List<ConceptoCalificacionDto>>
    { 
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }

    public class ConceptoCalificacionRegisterHandler : IRequestHandler<ConceptoCalificacionBuscarCommand, List<ConceptoCalificacionDto>>,
                                            IRequestHandler<ConceptoCalificacionBuscarTodoCommand, List<ConceptoCalificacionDto>>,
                                            IRequestHandler<ConceptoCalificacionBuscarIdCommand, ConceptoCalificacionDto>,
        IRequestHandler<ConceptoCalificacionPaginadoBuscarCommand, List<ConceptoCalificacionDto>>
    {
        private readonly IRepositoryConceptoCalificacion _repositoryConceptoCalificacion;
        private readonly IMapper _mapper;

        public ConceptoCalificacionRegisterHandler(IRepositoryConceptoCalificacion repositoryConceptoCalificacion, IMapper mapper)
        {
            _repositoryConceptoCalificacion = repositoryConceptoCalificacion;
            _mapper = mapper;
        }

        public async Task<List<ConceptoCalificacionDto>> Handle(ConceptoCalificacionBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.ConceptoCalificacion> conceptoCalificaciones = await _repositoryConceptoCalificacion.BuscarAsync(x=>x.ConceptoCalificacionId == (request.ConceptoCalificacionId ?? x.ConceptoCalificacionId) && x.Descripcion == (request.Descripcion ?? x.Descripcion) && x.Nombre == (request.Nombre ?? x.Nombre) && x.Nombre == (request.Nombre ?? x.Nombre));
            return _mapper.Map<List<ConceptoCalificacionDto>>(conceptoCalificaciones);

        }

        public async Task<List<ConceptoCalificacionDto>> Handle(ConceptoCalificacionBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.ConceptoCalificacion> conceptoCalificaciones = await _repositoryConceptoCalificacion.GetAllAsync();
            return _mapper.Map<List<ConceptoCalificacionDto>>(conceptoCalificaciones);
        }

        public async Task<ConceptoCalificacionDto> Handle(ConceptoCalificacionBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var ConceptoCalificaciones = await _repositoryConceptoCalificacion.TraerUnoAsync(x=>x.ConceptoCalificacionId == request.ConceptoCalificacionId);
            return _mapper.Map<ConceptoCalificacionDto>(ConceptoCalificaciones);
        }

        public async Task<List<ConceptoCalificacionDto>> Handle(ConceptoCalificacionPaginadoBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.ConceptoCalificacion> conceptoCalificaciones = await _repositoryConceptoCalificacion.BuscarPaginadoAsync(x =>  x.Descripcion == (request.Descripcion ?? x.Descripcion) && x.Nombre == (request.Nombre ?? x.Nombre) && x.Nombre == (request.Nombre ?? x.Nombre),request.NumeroPagina,request.NumeroPagina);
            return _mapper.Map<List<ConceptoCalificacionDto>>(conceptoCalificaciones);
        }
    }

}
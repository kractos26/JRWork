using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.TipoPersona;

public class Buscar
{

    public class TipoIdentificacionBuscarCommand : IRequest<List<TipoIdentificacionDto>>
    {
        public int? TipoPersonaId { get; set; }

        public string? Nombre { get; set; } 
    }

    public class TipoIdentificacionBuscarTodoCommand : IRequest<List<TipoIdentificacionDto>>
    {

    }

    public class TipoIdentificacionBuscarIdCommand : IRequest<TipoIdentificacionDto>
    {
        public int TipoIdentificacionId { get; set; }
    }

    public class TipoIdentificacionRegisterHandler : IRequestHandler<TipoIdentificacionBuscarCommand, List<TipoIdentificacionDto>>,
                                            IRequestHandler<TipoIdentificacionBuscarTodoCommand, List<TipoIdentificacionDto>>,
                                            IRequestHandler<TipoIdentificacionBuscarIdCommand, TipoIdentificacionDto>
    {
        private readonly IRepositoryTipoIdentificacion _repositoryTipoIdentificacion;
        private readonly IMapper _mapper;

        public TipoIdentificacionRegisterHandler(IRepositoryTipoIdentificacion repositoryTipoIdentificacion, IMapper mapper)
        {
            _repositoryTipoIdentificacion = repositoryTipoIdentificacion;
            _mapper = mapper;
        }

        public async Task<List<TipoIdentificacionDto>> Handle(TipoIdentificacionBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoIdentificacion> TipoIdentificaciones = await _repositoryTipoIdentificacion.BuscarAsync(x=>x.TipoDocumentoId == (request.TipoDocumentoId ?? x.TipoDocumentoId) && x.Nombre == (request.Nombre ?? x.Nombre) && x.Sigla == (request.Sigla ?? x.Sigla));
            return _mapper.Map<List<TipoIdentificacionDto>>(TipoIdentificaciones);

        }

        public async Task<List<TipoIdentificacionDto>> Handle(TipoIdentificacionBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoIdentificacion> TipoIdentificaciones = await _repositoryTipoIdentificacion.GetAllAsync();
            return _mapper.Map<List<TipoIdentificacionDto>>(TipoIdentificaciones);
        }

        public async Task<TipoIdentificacionDto> Handle(TipoIdentificacionBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var TipoIdentificaciones = await _repositoryTipoIdentificacion.TraerUnoAsync(x=>x.TipoDocumentoId == request.TipoIdentificacionId);
            return _mapper.Map<TipoIdentificacionDto>(TipoIdentificaciones);
        }
    }

}
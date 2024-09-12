using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.TipoDocumento;

public class Buscar
{

    public class TipoDocumentoBuscarCommand : IRequest<List<TipoDocumentoDto>>
    {
        public int? TipoDocumentoId { get; set; }

        public string? Nombre { get; set; } 
    }

    public class TipoDocumentoBuscarTodoCommand : IRequest<List<TipoDocumentoDto>>
    {

    }

    public class TipoDocumentoBuscarIdCommand : IRequest<TipoDocumentoDto>
    {
        public int TipoDocumentoId { get; set; }
    }

    public class TipoDocumentoRegisterHandler : IRequestHandler<TipoDocumentoBuscarCommand, List<TipoDocumentoDto>>,
                                            IRequestHandler<TipoDocumentoBuscarTodoCommand, List<TipoDocumentoDto>>,
                                            IRequestHandler<TipoDocumentoBuscarIdCommand, TipoDocumentoDto>
    {
        private readonly IRepositoryTipoDocumento _repositoryTipoDocumento;
        private readonly IMapper _mapper;

        public TipoDocumentoRegisterHandler(IRepositoryTipoDocumento repositoryTipoDocumento, IMapper mapper)
        {
            _repositoryTipoDocumento = repositoryTipoDocumento;
            _mapper = mapper;
        }

        public async Task<List<TipoDocumentoDto>> Handle(TipoDocumentoBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoDocumento> TipoDocumentoes = await _repositoryTipoDocumento.BuscarAsync(x=>x.TipoDocumentoId == (request.TipoDocumentoId ?? x.TipoDocumentoId) && x.Nombre == (request.Nombre ?? x.Nombre));
            return _mapper.Map<List<TipoDocumentoDto>>(TipoDocumentoes);

        }

        public async Task<List<TipoDocumentoDto>> Handle(TipoDocumentoBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoDocumento> TipoDocumentoes = await _repositoryTipoDocumento.GetAllAsync();
            return _mapper.Map<List<TipoDocumentoDto>>(TipoDocumentoes);
        }

        public async Task<TipoDocumentoDto> Handle(TipoDocumentoBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var TipoDocumentoes = await _repositoryTipoDocumento.TraerUnoAsync(x=>x.TipoDocumentoId == request.TipoDocumentoId);
            return _mapper.Map<TipoDocumentoDto>(TipoDocumentoes);
        }
    }

}
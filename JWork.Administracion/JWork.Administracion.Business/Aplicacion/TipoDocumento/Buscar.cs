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

    public class TipoDocumentoBuscarPaginadoCommand : IRequest<List<TipoDocumentoDto>>
    {
        public string? Nombre { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
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
                                            IRequestHandler<TipoDocumentoBuscarIdCommand, TipoDocumentoDto>,
        IRequestHandler<TipoDocumentoBuscarPaginadoCommand, List<TipoDocumentoDto>>
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

        public async Task<List<TipoDocumentoDto>> Handle(TipoDocumentoBuscarPaginadoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoDocumento> TipoDocumentoes = await _repositoryTipoDocumento.BuscarPaginadoAsync(x => x.Nombre == (request.Nombre ?? x.Nombre),request.NumeroPagina,request.TamanoPagina);
            return _mapper.Map<List<TipoDocumentoDto>>(TipoDocumentoes);
        }
    }

}
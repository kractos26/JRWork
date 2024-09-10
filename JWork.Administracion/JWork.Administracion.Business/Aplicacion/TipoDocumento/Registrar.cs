using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.TipoDocumento;

public class Registrar
{
    public class TipoDocumentoRegisterCommand : IRequest<TipoDocumentoDto>
    {

        public string Nombre { get; set; } = null!;
    }

    public class TipoDocumentoUpdateCommand : IRequest<TipoDocumentoDto>
    {
        public int TipoDocumentoId { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class TipoDocumentoEliminarCommand : IRequest<bool>
    {
        public int TipoDocumentoId { get; set; }
    }

    public class TipoDocumentoRegisterHandler : IRequestHandler<TipoDocumentoRegisterCommand, TipoDocumentoDto>,
        IRequestHandler<TipoDocumentoUpdateCommand, TipoDocumentoDto>,
        IRequestHandler<TipoDocumentoEliminarCommand, bool>
    {
        private readonly IRepositoryTipoDocumento _repositoryTipoDocumento;
        private readonly IMapper _mapper;

        public TipoDocumentoRegisterHandler(IRepositoryTipoDocumento repositoryTipoDocumento, IMapper mapper)
        {
            _repositoryTipoDocumento = repositoryTipoDocumento;
            _mapper = mapper;
        }

        public async Task<TipoDocumentoDto> Handle(TipoDocumentoRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoDocumento? tipoDocumentoExistente = await _repositoryTipoDocumento.TraerUnoAsync(x => x.Nombre == request.Nombre) ?? throw new InvalidOperationException("La TipoDocumento ya está registrada.");

            JRWork.Administracion.DataAccess.Models.TipoDocumento tipoDocumento = new()
            {
                Nombre = request.Nombre,
            };

            JRWork.Administracion.DataAccess.Models.TipoDocumento result = await _repositoryTipoDocumento.AdicionarAsync(tipoDocumento);

            return _mapper.Map<TipoDocumentoDto>(result);
        }

        public async Task<bool> Handle(TipoDocumentoEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoDocumento? tipodocumentoExistente = await _repositoryTipoDocumento.TraerUnoAsync(x => x.TipoDocumentoId == request.TipoDocumentoId) ?? throw new InvalidOperationException("La TipoDocumento no existe.");
            return await _repositoryTipoDocumento.EliminarAsync(tipodocumentoExistente);
        }

        public async Task<TipoDocumentoDto> Handle(TipoDocumentoUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoDocumento? tipoDocumentoExistente = await _repositoryTipoDocumento.TraerUnoAsync(x => x.TipoDocumentoId == request.TipoDocumentoId) ?? throw new InvalidOperationException("La tipoDocumento no existe.");
            tipoDocumentoExistente.Nombre = request.Nombre;
            var result = await _repositoryTipoDocumento.ModificarAsync(tipoDocumentoExistente);
            return _mapper.Map<TipoDocumentoDto>(result);
        }
    }
}

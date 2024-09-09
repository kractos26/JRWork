using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.TipoDocumento;

public class Registrar
{
    public class TipoDocumentoRegisterCommand : IRequest<TipoDocumentoDto>
    {
        public int TipoDocumentoId { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class TipoDocumentoRegisterHandler : IRequestHandler<TipoDocumentoRegisterCommand, TipoDocumentoDto>
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
            JRWork.Administracion.DataAccess.Models.TipoDocumento? actividadExistente = await _repositoryTipoDocumento.TraerUnoAsync(x => x.Nombre == request.Nombre);
            if (actividadExistente != null)
            {
                throw new InvalidOperationException("La TipoDocumento ya está registrada.");
            }

            JRWork.Administracion.DataAccess.Models.TipoDocumento actividad = new()
            {
                Nombre = request.Nombre,
                TipoDocumentoId = request.TipoDocumentoId
            };

            JRWork.Administracion.DataAccess.Models.TipoDocumento result = await _repositoryTipoDocumento.AdicionarAsync(actividad);

            return _mapper.Map<TipoDocumentoDto>(result);
        }
    }
}

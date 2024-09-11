using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Business.Aplicacion.TipoIdentificacion;

public class Registrar
{
    public class TipoIdentificacionRegisterCommand : IRequest<TipoIdentificacionDto>
    {
        public string Sigla { get; set; } = null!;
        public string Nombre { get; set; } = null!;
    }

    public class TipoIdentificacionUpdateCommand : IRequest<TipoIdentificacionDto>
    {
        public int TipoDocumentoId { get; set; }
        public string Sigla { get; set; } = null!;
        public string Nombre { get; set; } = null!;
    }

    public class TipoIdentificacionEliminarCommand : IRequest<bool>
    {
        public int TipoDocumentoId { get; set; }
    }

    public class TipoIdentificacionRegisterHandler : IRequestHandler<TipoIdentificacionRegisterCommand, TipoIdentificacionDto>,
        IRequestHandler<TipoIdentificacionUpdateCommand, TipoIdentificacionDto>,
        IRequestHandler<TipoIdentificacionEliminarCommand, bool>
    {
        private readonly IRepositoryTipoIdentificacion _repositoryTipoIdentificacion;
        private readonly IMapper _mapper;

        public TipoIdentificacionRegisterHandler(IRepositoryTipoIdentificacion repositoryTipoIdentificacion, IMapper mapper)
        {
            _repositoryTipoIdentificacion = repositoryTipoIdentificacion;
            _mapper = mapper;
        }

        public async Task<TipoIdentificacionDto> Handle(TipoIdentificacionRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoIdentificacion? tipoIdentificacionExistente = await _repositoryTipoIdentificacion.TraerUnoAsync(x => x.Nombre == request.Nombre) ?? throw new InvalidOperationException("La TipoIdentificacion ya está registrada.");

            JRWork.Administracion.DataAccess.Models.TipoIdentificacion tipoIdentificacion = new()
            {
                Nombre = request.Nombre,
            };

            JRWork.Administracion.DataAccess.Models.TipoIdentificacion result = await _repositoryTipoIdentificacion.AdicionarAsync(tipoIdentificacion);

            return _mapper.Map<TipoIdentificacionDto>(result);
        }

        public async Task<bool> Handle(TipoIdentificacionEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoIdentificacion? tipoIdentificacionExistente = await _repositoryTipoIdentificacion.TraerUnoAsync(x => x.TipoDocumentoId == request.TipoDocumentoId) ?? throw new InvalidOperationException("La TipoIdentificacion no existe.");
            return await _repositoryTipoIdentificacion.EliminarAsync(tipoIdentificacionExistente);
        }

        public async Task<TipoIdentificacionDto> Handle(TipoIdentificacionUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoIdentificacion? tipoIdentificacionExistente = await _repositoryTipoIdentificacion.TraerUnoAsync(x => x.TipoDocumentoId == request.TipoDocumentoId) ?? throw new InvalidOperationException("La tipoIdentificacion no existe.");
            tipoIdentificacionExistente.Nombre = request.Nombre;
            var result = await _repositoryTipoIdentificacion.ModificarAsync(tipoIdentificacionExistente);
            return _mapper.Map<TipoIdentificacionDto>(result);
        }
    }
}

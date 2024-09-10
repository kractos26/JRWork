using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.TipoPersona;

public class Registrar
{
    public class TipoPersonaRegisterCommand : IRequest<TipoPersonaDto>
    {
        public string Nombre { get; set; } = null!;
    }

    public class TipoPersonaUpdateCommand : IRequest<TipoPersonaDto>
    {
        public int TipoPersonaId { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class TipoPersonaEliminarCommand : IRequest<bool>
    {
        public int TipoPersonaId { get; set; }

    }
    public class TipoPersonaRegisterHandler : IRequestHandler<TipoPersonaRegisterCommand, TipoPersonaDto>,
        IRequestHandler<TipoPersonaUpdateCommand, TipoPersonaDto>,
        IRequestHandler<TipoPersonaEliminarCommand, bool>
    {
        private readonly IRepositoryTipoPersona _repositoryTipoPersona;
        private readonly IMapper _mapper;

        public TipoPersonaRegisterHandler(IRepositoryTipoPersona repositoryTipoPersona, IMapper mapper)
        {
            _repositoryTipoPersona = repositoryTipoPersona;
            _mapper = mapper;
        }

        public async Task<TipoPersonaDto> Handle(TipoPersonaRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoPersona? actividadExistente = await _repositoryTipoPersona.TraerUnoAsync(x => x.Nombre == request.Nombre) ?? throw new InvalidOperationException("El TipoPersona ya está registrada.");


            JRWork.Administracion.DataAccess.Models.TipoPersona actividad = new()
            {
                Nombre = request.Nombre,
            };

            JRWork.Administracion.DataAccess.Models.TipoPersona result = await _repositoryTipoPersona.AdicionarAsync(actividad);

            return _mapper.Map<TipoPersonaDto>(result);
        }

        public async Task<bool> Handle(TipoPersonaEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoPersona? tipoPersonaExistente = await _repositoryTipoPersona.TraerUnoAsync(x => x.TipoPersonaId == request.TipoPersonaId) ?? throw new InvalidOperationException("La TipoPersona no existe.");
            return await _repositoryTipoPersona.EliminarAsync(tipoPersonaExistente);
        }

        public async Task<TipoPersonaDto> Handle(TipoPersonaUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.TipoPersona? tipoPersonaExistente = await _repositoryTipoPersona.TraerUnoAsync(x => x.TipoPersonaId == request.TipoPersonaId) ?? throw new InvalidOperationException("La TipoPersona no existe.");
            tipoPersonaExistente.Nombre = request.Nombre;
            var result = await _repositoryTipoPersona.ModificarAsync(tipoPersonaExistente);
            return _mapper.Map<TipoPersonaDto>(result);
        }
    }
}

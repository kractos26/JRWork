using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.UnidadMedida;

public class Registrar
{
    public class UnidadMedidaRegisterCommand : IRequest<UnidadMedidaDto>
    {
        public string Nombre { get; set; } = null!;
    }

    public class UnidadMedidaUpdateCommand : IRequest<UnidadMedidaDto>
    {
        public int UnidadMedidaId { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class UnidadMedidaEliminarCommand : IRequest<bool>
    {
        public int UnidadMedidaId { get; set; }

    }

    public class UnidadMedidaRegisterHandler : IRequestHandler<UnidadMedidaRegisterCommand, UnidadMedidaDto>,
        IRequestHandler<UnidadMedidaUpdateCommand, UnidadMedidaDto>,
        IRequestHandler<UnidadMedidaEliminarCommand, bool>

    {
        private readonly IRepositoryUnidadMedida _repositoryUnidadMedida;
        private readonly IMapper _mapper;

        public UnidadMedidaRegisterHandler(IRepositoryUnidadMedida repositoryUnidadMedida, IMapper mapper)
        {
            _repositoryUnidadMedida = repositoryUnidadMedida;
            _mapper = mapper;
        }

        public async Task<UnidadMedidaDto> Handle(UnidadMedidaRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.UnidadMedida? actividadExistente = await _repositoryUnidadMedida.TraerUnoAsync(x => x.Nombre == request.Nombre) ?? throw new InvalidOperationException("La UnidadMedida ya está registrada.");
            JRWork.Administracion.DataAccess.Models.UnidadMedida actividad = new()
            {
                Nombre = request.Nombre
            };

            JRWork.Administracion.DataAccess.Models.UnidadMedida result = await _repositoryUnidadMedida.AdicionarAsync(actividad);

            return _mapper.Map<UnidadMedidaDto>(result);
        }

        public async Task<UnidadMedidaDto> Handle(UnidadMedidaUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.UnidadMedida? unidadMedidaExistente = await _repositoryUnidadMedida.TraerUnoAsync(x => x.UnidadMedidaId == request.UnidadMedidaId) ?? throw new InvalidOperationException("La UnidadMedida no existe.");
            unidadMedidaExistente.Nombre = request.Nombre;
            var result = await _repositoryUnidadMedida.ModificarAsync(unidadMedidaExistente);
            return _mapper.Map<UnidadMedidaDto>(result);
        }

        public async Task<bool> Handle(UnidadMedidaEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.UnidadMedida? unidadMedidaExistente = await _repositoryUnidadMedida.TraerUnoAsync(x => x.UnidadMedidaId == request.UnidadMedidaId) ?? throw new InvalidOperationException("La UnidadMedida no existe.");
            return await _repositoryUnidadMedida.EliminarAsync(unidadMedidaExistente);
        }
    }
}

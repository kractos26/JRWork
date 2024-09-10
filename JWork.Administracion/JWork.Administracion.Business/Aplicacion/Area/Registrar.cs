using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Area;
public class Registrar
{
    public class AreaRegisterCommand : IRequest<AreaDto>
    {
        public int AreaId { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class AreaUpdateCommand : IRequest<AreaDto>
    {
        public int AreaId { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class AreaEliminarCommand : IRequest<bool>
    {
        public int AreaId { get; set; }
    }
    public class AreaRegisterHandler : IRequestHandler<AreaRegisterCommand, AreaDto>
        , IRequestHandler<AreaUpdateCommand, AreaDto>
        , IRequestHandler<AreaEliminarCommand, bool>
    {
        private readonly IRepositoryArea _repositoryArea;
        private readonly IMapper _mapper;

        public AreaRegisterHandler(IRepositoryArea repositoryArea, IMapper mapper)
        {
            _repositoryArea = repositoryArea;
            _mapper = mapper;
        }

        public async Task<AreaDto> Handle(AreaRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Area? areaExistente = await _repositoryArea.TraerUnoAsync(x => x.Nombre == request.Nombre) ?? throw new InvalidOperationException("El area ya está registrada.");

            JRWork.Administracion.DataAccess.Models.Area actividad = new()
            {
                Nombre = request.Nombre,
                AreaId = request.AreaId
            };

            JRWork.Administracion.DataAccess.Models.Area result = await _repositoryArea.AdicionarAsync(actividad);

            return _mapper.Map<AreaDto>(result);
        }

        async Task<bool> IRequestHandler<AreaEliminarCommand, bool>.Handle(AreaEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Area? areaExistente = await _repositoryArea.TraerUnoAsync(x => x.AreaId == request.AreaId) ?? throw new InvalidOperationException("La area no existe.");
            return await _repositoryArea.EliminarAsync(areaExistente);
        }

        async Task<AreaDto> IRequestHandler<AreaUpdateCommand, AreaDto>.Handle(AreaUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Area? areaExistente = await _repositoryArea.TraerUnoAsync(x => x.AreaId == request.AreaId) ?? throw new InvalidOperationException("La actividad no existe.");
            areaExistente.Nombre = request.Nombre;
            var result = await _repositoryArea.ModificarAsync(areaExistente);
            return _mapper.Map<AreaDto>(result);
        }
    }

}
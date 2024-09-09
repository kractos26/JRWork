using AutoMapper;
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

    public class AreaRegisterHandler : IRequestHandler<AreaRegisterCommand, AreaDto>
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
            JRWork.Administracion.DataAccess.Models.Area? actividadExistente = await _repositoryArea.TraerUnoAsync(x => x.Nombre == request.Nombre);
            if (actividadExistente != null)
            {
                throw new InvalidOperationException("El area ya está registrada.");
            }

            JRWork.Administracion.DataAccess.Models.Area actividad = new()
            {
                Nombre = request.Nombre,
                AreaId = request.AreaId
            };

            JRWork.Administracion.DataAccess.Models.Area result = await _repositoryArea.AdicionarAsync(actividad);

            return _mapper.Map<AreaDto>(result);
        }
    }

}
using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Area;

public class Buscar
{

    public class AreaBuscarCommand : IRequest<List<AreaDto>>
    {
        public int? AreaId { get; set; }
        public string? Nombre { get; set; } = null!;
    }

    public class AreaBuscarTodoCommand : IRequest<List<AreaDto>>
    {

    }

    public class AreaBuscarIdCommand : IRequest<AreaDto>
    {
        public int AreaId { get; set; }
    }

    public class AreaRegisterHandler : IRequestHandler<AreaBuscarCommand, List<AreaDto>>,
                                            IRequestHandler<AreaBuscarTodoCommand, List<AreaDto>>,
                                            IRequestHandler<AreaBuscarIdCommand, AreaDto>
    {
        private readonly IRepositoryArea _repositoryArea;
        private readonly IMapper _mapper;

        public AreaRegisterHandler(IRepositoryArea repositoryArea, IMapper mapper)
        {
            _repositoryArea = repositoryArea;
            _mapper = mapper;
        }

        public async Task<List<AreaDto>> Handle(AreaBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Area> Areaes = await _repositoryArea.BuscarAsync(x => x.AreaId == (request.AreaId ?? x.AreaId) && x.Nombre == (request.Nombre ?? x.Nombre));
            return _mapper.Map<List<AreaDto>>(Areaes);

        }

        public async Task<List<AreaDto>> Handle(AreaBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Area> Areaes = await _repositoryArea.GetAllAsync();
            return _mapper.Map<List<AreaDto>>(Areaes);
        }

        public async Task<AreaDto> Handle(AreaBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var Areaes = await _repositoryArea.TraerUnoAsync(x => x.AreaId == request.AreaId);
            return _mapper.Map<AreaDto>(Areaes);
        }
    }

}
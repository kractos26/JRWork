using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Area;

public class Buscar
{
    public class AreaBuscarPaginadoCommand:IRequest<List<AreaDto>>
    {
        public string? Nombre { get; set; } = null!;
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }

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
                                            IRequestHandler<AreaBuscarIdCommand, AreaDto>,
                                            IRequestHandler<AreaBuscarPaginadoCommand,List<AreaDto>>
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
            JRWork.Administracion.DataAccess.Models.Area? areas = await _repositoryArea.TraerUnoAsync(x => x.AreaId == request.AreaId);
            return _mapper.Map<AreaDto>(areas);
        }

        public async Task<List<AreaDto>> Handle(AreaBuscarPaginadoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Area> areas = await _repositoryArea.BuscarPaginadoAsync(x => x.Nombre == (request.Nombre ?? x.Nombre), request.NumeroPagina, request.TamanoPagina);
            return _mapper.Map<List<AreaDto>>(areas);
        }
    }

}
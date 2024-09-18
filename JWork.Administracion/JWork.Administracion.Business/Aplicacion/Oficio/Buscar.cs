using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Oficio;

public class Buscar
{

    public class OficioBuscarCommand : IRequest<List<OficioDto>>
    {
        public int? OficioId { get; set; }

        public string? Nombre { get; set; }

        public int? AreaId { get; set; }
    }

    public class OficioBuscarPaginadoCommand : IRequest<List<OficioDto>>
    {
        public string? Nombre { get; set; }

        public int? AreaId { get; set; }

        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }

    public class OficioBuscarTodoCommand : IRequest<List<OficioDto>>
    {

    }

    public class OficioBuscarIdCommand : IRequest<OficioDto>
    {
        public int OficioId { get; set; }
    }

    public class OficioRegisterHandler : IRequestHandler<OficioBuscarCommand, List<OficioDto>>,
                                            IRequestHandler<OficioBuscarTodoCommand, List<OficioDto>>,
                                            IRequestHandler<OficioBuscarIdCommand, OficioDto>,
        IRequestHandler<OficioBuscarPaginadoCommand, List<OficioDto>>
    {
        private readonly IRepositoryOficio _repositoryOficio;
        private readonly IMapper _mapper;

        public OficioRegisterHandler(IRepositoryOficio repositoryOficio, IMapper mapper)
        {
            _repositoryOficio = repositoryOficio;
            _mapper = mapper;
        }

        public async Task<List<OficioDto>> Handle(OficioBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Oficio> Oficioes = await _repositoryOficio.BuscarAsync(x=>x.OficioId == (request.OficioId ?? x.OficioId) && x.Nombre!.Contains(request.Nombre ?? x.Nombre) && x.AreaId == (request.AreaId ?? x.AreaId));
            return _mapper.Map<List<OficioDto>>(Oficioes);

        }

        public async Task<List<OficioDto>> Handle(OficioBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Oficio> Oficioes = await _repositoryOficio.GetAllAsync();
            return _mapper.Map<List<OficioDto>>(Oficioes);
        }

        public async Task<OficioDto> Handle(OficioBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var Oficioes = await _repositoryOficio.TraerUnoAsync(x=>x.OficioId == request.OficioId);
            return _mapper.Map<OficioDto>(Oficioes);
        }

        public async Task<List<OficioDto>> Handle(OficioBuscarPaginadoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Oficio> Oficioes = await _repositoryOficio.BuscarPaginadoAsync(x => x.Nombre!.Contains(request.Nombre ?? x.Nombre) && x.AreaId == (request.AreaId ?? x.AreaId),request.NumeroPagina,request.TamanoPagina);
            return _mapper.Map<List<OficioDto>>(Oficioes);
        }
    }

}
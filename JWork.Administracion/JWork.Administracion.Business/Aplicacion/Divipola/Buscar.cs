using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Divipola;

public class Buscar
{

    public class DivipolaBuscarCommand : IRequest<List<DivipolaDto>>
    {
        public int? DivipolaId { get; set; }

        public decimal? Codigo { get; set; }

        public string? Nombre { get; set; }

        public decimal? CodigoPadre { get; set; }
    }

    public class DivipolaBuscarPaginadoCommand : IRequest<List<DivipolaDto>>
    {

        public decimal? Codigo { get; set; }

        public string? Nombre { get; set; }

        public decimal? CodigoPadre { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }
    public class DivipolaBuscarTodoCommand : IRequest<List<DivipolaDto>>
    {

    }

    public class DivipolaBuscarIdCommand : IRequest<DivipolaDto>
    {
        public int DivipolaId { get; set; }
    }

    public class DivipolaRegisterHandler : IRequestHandler<DivipolaBuscarCommand, List<DivipolaDto>>,
                                            IRequestHandler<DivipolaBuscarTodoCommand, List<DivipolaDto>>,
                                            IRequestHandler<DivipolaBuscarIdCommand, DivipolaDto>,
        IRequestHandler<DivipolaBuscarPaginadoCommand, List<DivipolaDto>>
    {
        private readonly IRepositoryDivipola _repositoryDivipola;
        private readonly IMapper _mapper;

        public DivipolaRegisterHandler(IRepositoryDivipola repositoryDivipola, IMapper mapper)
        {
            _repositoryDivipola = repositoryDivipola;
            _mapper = mapper;
        }

        public async Task<List<DivipolaDto>> Handle(DivipolaBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Divipola> Divipolaes = await _repositoryDivipola.BuscarAsync(x=>x.DivipolaId == (request.DivipolaId ?? x.DivipolaId) && x.Codigo == (request.Codigo ?? x.Codigo) && x.Nombre == (request.Nombre ?? x.Nombre) && x.CodigoPadre == (request.CodigoPadre ?? x.CodigoPadre));
            return _mapper.Map<List<DivipolaDto>>(Divipolaes);

        }

        public async Task<List<DivipolaDto>> Handle(DivipolaBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Divipola> Divipolaes = await _repositoryDivipola.GetAllAsync();
            return _mapper.Map<List<DivipolaDto>>(Divipolaes);
        }

        public async Task<DivipolaDto> Handle(DivipolaBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var Divipolaes = await _repositoryDivipola.TraerUnoAsync(x=>x.DivipolaId == request.DivipolaId);
            return _mapper.Map<DivipolaDto>(Divipolaes);
        }

        public async Task<List<DivipolaDto>> Handle(DivipolaBuscarPaginadoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.Divipola> Divipolaes = await _repositoryDivipola.BuscarPaginadoAsync(x =>  x.Codigo == (request.Codigo ?? x.Codigo) && x.Nombre == (request.Nombre ?? x.Nombre) && x.CodigoPadre == (request.CodigoPadre ?? x.CodigoPadre),request.NumeroPagina,request.TamanoPagina);
            return _mapper.Map<List<DivipolaDto>>(Divipolaes);
        }
    }

}
using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.UnidadMedida;

public class Buscar
{

    public class UnidadMedidaBuscarCommand : IRequest<List<UnidadMedidaDto>>
    {
        public int? UnidadMedidaId { get; set; }

        public string? Nombre { get; set; }
    }

    public class UnidadMedidaBuscarPaginoCommand : IRequest<List<UnidadMedidaDto>>
    {

        public string? Nombre { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }

    public class UnidadMedidaBuscarTodoCommand : IRequest<List<UnidadMedidaDto>>
    {

    }

    public class UnidadMedidaBuscarIdCommand : IRequest<UnidadMedidaDto>
    {
        public int UnidadMedidaId { get; set; }
    }

    public class UnidadMedidaRegisterHandler : IRequestHandler<UnidadMedidaBuscarCommand, List<UnidadMedidaDto>>,
                                            IRequestHandler<UnidadMedidaBuscarTodoCommand, List<UnidadMedidaDto>>,
                                            IRequestHandler<UnidadMedidaBuscarIdCommand, UnidadMedidaDto>,
        IRequestHandler<UnidadMedidaBuscarPaginoCommand, List<UnidadMedidaDto>>
    {
        private readonly IRepositoryUnidadMedida _repositoryUnidadMedida;
        private readonly IMapper _mapper;

        public UnidadMedidaRegisterHandler(IRepositoryUnidadMedida repositoryUnidadMedida, IMapper mapper)
        {
            _repositoryUnidadMedida = repositoryUnidadMedida;
            _mapper = mapper;
        }

        public async Task<List<UnidadMedidaDto>> Handle(UnidadMedidaBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.UnidadMedida> UnidadMedidaes = await _repositoryUnidadMedida.BuscarAsync(x=>x.UnidadMedidaId == (request.UnidadMedidaId ?? x.UnidadMedidaId) && x.Nombre == (request.Nombre ?? x.Nombre));
            return _mapper.Map<List<UnidadMedidaDto>>(UnidadMedidaes);

        }

        public async Task<List<UnidadMedidaDto>> Handle(UnidadMedidaBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.UnidadMedida> UnidadMedidaes = await _repositoryUnidadMedida.GetAllAsync();
            return _mapper.Map<List<UnidadMedidaDto>>(UnidadMedidaes);
        }

        public async Task<UnidadMedidaDto> Handle(UnidadMedidaBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var UnidadMedidaes = await _repositoryUnidadMedida.TraerUnoAsync(x=>x.UnidadMedidaId == request.UnidadMedidaId);
            return _mapper.Map<UnidadMedidaDto>(UnidadMedidaes);
        }

        public async Task<List<UnidadMedidaDto>> Handle(UnidadMedidaBuscarPaginoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.UnidadMedida> UnidadMedidaes = await _repositoryUnidadMedida.BuscarPaginadoAsync(x =>  x.Nombre == (request.Nombre ?? x.Nombre),request.NumeroPagina,request.TamanoPagina);
            return _mapper.Map<List<UnidadMedidaDto>>(UnidadMedidaes);
        }
    }

}
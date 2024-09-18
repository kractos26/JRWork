using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.TipoPersona;

public class Buscar
{

    public class TipoPersonaBuscarCommand : IRequest<List<TipoPersonaDto>>
    {
        public int? TipoPersonaId { get; set; }

        public string? Nombre { get; set; } 
    }

    public class TipoPersonaPaginadoBuscarCommand : IRequest<List<TipoPersonaDto>>
    {

        public string? Nombre { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int TamanoPagina { get; set; } = 10;
    }


    public class TipoPersonaBuscarTodoCommand : IRequest<List<TipoPersonaDto>>
    {

    }

    public class TipoPersonaBuscarIdCommand : IRequest<TipoPersonaDto>
    {
        public int TipoPersonaId { get; set; }
    }

    public class TipoPersonaRegisterHandler : IRequestHandler<TipoPersonaBuscarCommand, List<TipoPersonaDto>>,
                                            IRequestHandler<TipoPersonaBuscarTodoCommand, List<TipoPersonaDto>>,
                                            IRequestHandler<TipoPersonaBuscarIdCommand, TipoPersonaDto>,
        IRequestHandler<TipoPersonaPaginadoBuscarCommand, List<TipoPersonaDto>>
    {
        private readonly IRepositoryTipoPersona _repositoryTipoPersona;
        private readonly IMapper _mapper;

        public TipoPersonaRegisterHandler(IRepositoryTipoPersona repositoryTipoPersona, IMapper mapper)
        {
            _repositoryTipoPersona = repositoryTipoPersona;
            _mapper = mapper;
        }

        public async Task<List<TipoPersonaDto>> Handle(TipoPersonaBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoPersona> TipoPersonaes = await _repositoryTipoPersona.BuscarAsync(x=>x.TipoPersonaId == (request.TipoPersonaId ?? x.TipoPersonaId) && x.Nombre == (request.Nombre ?? x.Nombre));
            return _mapper.Map<List<TipoPersonaDto>>(TipoPersonaes);

        }

        public async Task<List<TipoPersonaDto>> Handle(TipoPersonaBuscarTodoCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoPersona> TipoPersonaes = await _repositoryTipoPersona.GetAllAsync();
            return _mapper.Map<List<TipoPersonaDto>>(TipoPersonaes);
        }

        public async Task<TipoPersonaDto> Handle(TipoPersonaBuscarIdCommand request, CancellationToken cancellationToken)
        {
            var TipoPersonaes = await _repositoryTipoPersona.TraerUnoAsync(x=>x.TipoPersonaId == request.TipoPersonaId);
            return _mapper.Map<TipoPersonaDto>(TipoPersonaes);
        }

        public async Task<List<TipoPersonaDto>> Handle(TipoPersonaPaginadoBuscarCommand request, CancellationToken cancellationToken)
        {
            List<JRWork.Administracion.DataAccess.Models.TipoPersona> TipoPersonaes = await _repositoryTipoPersona.BuscarPaginadoAsync(x => x.Nombre == (request.Nombre ?? x.Nombre),request.NumeroPagina,request.TamanoPagina);
            return _mapper.Map<List<TipoPersonaDto>>(TipoPersonaes);
        }
    }

}
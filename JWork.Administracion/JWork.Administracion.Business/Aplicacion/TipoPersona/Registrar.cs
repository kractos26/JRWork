using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.TipoPersona
{
    public class Registrar
    {
        public class TipoPersonaRegisterCommand : IRequest<TipoPersonaDto>
        {
            public int TipoPersonaId { get; set; }

            public string Nombre { get; set; } = null!;
        }

        public class TipoPersonaRegisterHandler : IRequestHandler<TipoPersonaRegisterCommand, TipoPersonaDto>
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
                JRWork.Administracion.DataAccess.Models.TipoPersona? actividadExistente = await _repositoryTipoPersona.TraerUnoAsync(x => x.Nombre == request.Nombre);
                if (actividadExistente != null)
                {
                    throw new InvalidOperationException("El TipoPersona ya está registrada.");
                }

                JRWork.Administracion.DataAccess.Models.TipoPersona actividad = new()
                {
                    Nombre = request.Nombre,             
                    TipoPersonaId = request.TipoPersonaId
                };

                JRWork.Administracion.DataAccess.Models.TipoPersona result = await _repositoryTipoPersona.AdicionarAsync(actividad);

                return _mapper.Map<TipoPersonaDto>(result);
            }
        }
    }
}

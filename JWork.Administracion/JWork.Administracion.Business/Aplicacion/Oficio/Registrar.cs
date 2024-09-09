using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Oficio
{
    public class Registrar
    {
        public class OficioRegisterCommand : IRequest<OficioDto>
        {
            public int OficioId { get; set; }

            public string? Nombre { get; set; }

            public int? AreaId { get; set; }
        }

        public class OficioRegisterHandler : IRequestHandler<OficioRegisterCommand, OficioDto>
        {
            private readonly IRepositoryOficio _repositoryOficio;
            private readonly IMapper _mapper;

            public OficioRegisterHandler(IRepositoryOficio repositoryOficio, IMapper mapper)
            {
                _repositoryOficio = repositoryOficio;
                _mapper = mapper;
            }

            public async Task<OficioDto> Handle(OficioRegisterCommand request, CancellationToken cancellationToken)
            {
                JRWork.Administracion.DataAccess.Models.Oficio? actividadExistente = await _repositoryOficio.TraerUnoAsync(x => x.Nombre == request.Nombre);
                if (actividadExistente != null)
                {
                    throw new InvalidOperationException("La Oficio ya está registrada.");
                }

                JRWork.Administracion.DataAccess.Models.Oficio actividad = new()
                {
                    Nombre = request.Nombre,
                    AreaId = request.AreaId,
                    OficioId = request.OficioId
                };

                JRWork.Administracion.DataAccess.Models.Oficio result = await _repositoryOficio.AdicionarAsync(actividad);

                return _mapper.Map<OficioDto>(result);
            }
        }
    }
}

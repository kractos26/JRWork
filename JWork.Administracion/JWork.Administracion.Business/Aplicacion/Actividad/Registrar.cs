using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JWork.Administracion.Business.Aplicacion.Actividad
{
    public class ActividadRegisterCommand : IRequest<ActividadDto>
    {
        public int ActividadId { get; set; }

        public string Nombre { get; set; } = null!;

        public int OficioId { get; set; }
    }

    public class ActividadRegisterHandler : IRequestHandler<ActividadRegisterCommand, ActividadDto>
    {
        private readonly IRepositoryActividad _repositoryActividad;
        private readonly IMapper _mapper;

        public ActividadRegisterHandler(IRepositoryActividad repositoryActividad, IMapper mapper)
        {
            _repositoryActividad = repositoryActividad;
            _mapper = mapper;
        }

        public async Task<ActividadDto> Handle(ActividadRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Actividad? actividadExistente = await _repositoryActividad.TraerUnoAsync(x => x.Nombre == request.Nombre);
            if (actividadExistente != null)
            {
                throw new InvalidOperationException("La actividad ya está registrada.");
            }

            JRWork.Administracion.DataAccess.Models.Actividad actividad = new JRWork.Administracion.DataAccess.Models.Actividad
            {
                Nombre = request.Nombre,
                ActividadId = request.ActividadId,
                OficioId = request.OficioId
            };

            JRWork.Administracion.DataAccess.Models.Actividad result = await _repositoryActividad.AdicionarAsync(actividad);

           return _mapper.Map<ActividadDto>(result);
        }
    }
}

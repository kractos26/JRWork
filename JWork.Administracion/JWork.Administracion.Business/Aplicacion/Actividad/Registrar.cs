using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Actividad;

public class Registar
{

    public class ActividadRegisterCommand : IRequest<ActividadDto>
    {

        public string Nombre { get; set; } = null!;

        public int OficioId { get; set; }
    }

    public class ActividadUpdateCommand : IRequest<ActividadDto>
    {
        public int ActividadId { get; set; }
        public string Nombre { get; set; } = null!;
        public int OficioId { get; set; }
    }

    public class ActividadEliminarCommand : IRequest<bool>
    {
        public int ActividadId { get; set; }
    }

    public class ActividadRegisterHandler : IRequestHandler<ActividadRegisterCommand, ActividadDto>,
                                            IRequestHandler<ActividadUpdateCommand, ActividadDto>,
                                            IRequestHandler<ActividadEliminarCommand, bool>
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
            JRWork.Administracion.DataAccess.Models.Actividad? actividadExistente = await _repositoryActividad.TraerUnoAsync(x => x.Nombre == request.Nombre) ?? throw new InvalidOperationException("La actividad ya está registrada."); 

            JRWork.Administracion.DataAccess.Models.Actividad actividad = new()
            {
                Nombre = request.Nombre,
                OficioId = request.OficioId
            };

            JRWork.Administracion.DataAccess.Models.Actividad result = await _repositoryActividad.AdicionarAsync(actividad);

            return _mapper.Map<ActividadDto>(result);
        }

        public async Task<ActividadDto> Handle(ActividadUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Actividad? actividadExistente = await _repositoryActividad.TraerUnoAsync(x => x.ActividadId == request.ActividadId) ?? throw new InvalidOperationException("La actividad no existe."); 

            actividadExistente.Nombre = request.Nombre;
            actividadExistente.OficioId = request.OficioId;

            var result = await _repositoryActividad.ModificarAsync(actividadExistente);
            return _mapper.Map<ActividadDto>(result);
        }

        public async Task<bool> Handle(ActividadEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Actividad? actividadExistente = await _repositoryActividad.TraerUnoAsync(x => x.ActividadId == request.ActividadId) ?? throw new InvalidOperationException("La actividad no existe.");

            return  await _repositoryActividad.EliminarAsync(actividadExistente);
        }
    }

}
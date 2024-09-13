using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Habilidad;

public class Registrar
{
    public class HabilidadRegisterCommand : IRequest<HabilidadDto>
    {
        public string Nombre { get; set; } = null!;

        public int ActividadId { get; set; }
    }

    public class HabilidadUpdateCommand : IRequest<HabilidadDto>
    {
        public int HabilidadId { get; set; }

        public string Nombre { get; set; } = null!;

        public int ActividadId { get; set; }
    }


    public class HabilidadEliminarCommand : IRequest<bool>
    {
        public int HabilidadId { get; set; }
    }

    public class HabilidadRegisterHandler :
        IRequestHandler<HabilidadRegisterCommand, HabilidadDto>,
        IRequestHandler<HabilidadUpdateCommand, HabilidadDto>,
        IRequestHandler<HabilidadEliminarCommand,bool>
    {
        private readonly IRepositoryHabilidad _repositoryHabilidad;
        private readonly IMapper _mapper;

        public HabilidadRegisterHandler(IRepositoryHabilidad repositoryHabilidad, IMapper mapper)
        {
            _repositoryHabilidad = repositoryHabilidad;
            _mapper = mapper;
        }

        public async Task<HabilidadDto> Handle(HabilidadUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Habilidad? habildadExistente = await _repositoryHabilidad.TraerUnoAsync(x => x.HabilidadId == request.HabilidadId) ?? throw new InvalidOperationException("La actividad no existe.");
            habildadExistente.Nombre = request.Nombre;
            var result = await _repositoryHabilidad.ModificarAsync(habildadExistente);
            return _mapper.Map<HabilidadDto>(result);
        }

        public async Task<HabilidadDto> Handle(HabilidadRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Habilidad? habildadExistente = await _repositoryHabilidad.TraerUnoAsync(x => x.Nombre == request.Nombre);
             
            if(habildadExistente != null)
            {
                throw new InvalidOperationException("El Habilidad ya está registrada.");
            }
   
            JRWork.Administracion.DataAccess.Models.Habilidad actividad = new()
            {
                Nombre = request.Nombre,
                ActividadId = request.ActividadId
            };

            JRWork.Administracion.DataAccess.Models.Habilidad result = await _repositoryHabilidad.AdicionarAsync(actividad);

            return _mapper.Map<HabilidadDto>(result);
        }

        public async Task<bool> Handle(HabilidadEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Habilidad? habildadExistente = await _repositoryHabilidad.TraerUnoAsync(x => x.HabilidadId == request.HabilidadId) ?? throw new InvalidOperationException("La Habilidad no existe.");
           return await _repositoryHabilidad.EliminarAsync(habildadExistente);
        }
    }
}

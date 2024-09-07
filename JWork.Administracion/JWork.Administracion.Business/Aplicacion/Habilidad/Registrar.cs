using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Business.Aplicacion.Actividad;
using JWork.Administracion.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JWork.Administracion.Business.Aplicacion.Habilidad
{
    public class Registrar
    {
        public class HabilidadRegisterCommand : IRequest<HabilidadDto>
        {
            public int HabilidadId { get; set; }

            public string Nombre { get; set; } = null!;

            public int ActividadId { get; set; }
        }

        public class HabilidadRegisterHandler : IRequestHandler<HabilidadRegisterCommand, HabilidadDto>
        {
            private readonly IRepositoryHabilidad _repositoryHabilidad;
            private readonly IMapper _mapper;

            public HabilidadRegisterHandler(IRepositoryHabilidad repositoryHabilidad, IMapper mapper)
            {
                _repositoryHabilidad = repositoryHabilidad;
                _mapper = mapper;
            }

            public async Task<HabilidadDto> Handle(HabilidadRegisterCommand request, CancellationToken cancellationToken)
            {
                JRWork.Administracion.DataAccess.Models.Habilidad? actividadExistente = await _repositoryHabilidad.TraerUnoAsync(x => x.Nombre == request.Nombre);
                if (actividadExistente != null)
                {
                    throw new InvalidOperationException("La habilidad ya está registrada.");
                }

                JRWork.Administracion.DataAccess.Models.Habilidad actividad = new()
                {
                    Nombre = request.Nombre,
                    ActividadId = request.ActividadId,
                    HabilidadId = request.HabilidadId
                };

                JRWork.Administracion.DataAccess.Models.Habilidad result = await _repositoryHabilidad.AdicionarAsync(actividad);

                return _mapper.Map<HabilidadDto>(result);
            }
        }
    }
}

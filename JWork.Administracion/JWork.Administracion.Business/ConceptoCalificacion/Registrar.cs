using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.ConceptoCalificacion;

public class Registrar
{
    public class ConceptoCalificacionRegisterCommand : IRequest<ConceptoCalificacionDto>
    {
        public int ConceptoCalificacionId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }
    }

    public class ConceptoCalificacionRegisterHandler : IRequestHandler<ConceptoCalificacionRegisterCommand, ConceptoCalificacionDto>
    {
        private readonly IRepositoryConceptoCalificacion _repositoryConceptoCalificacion;
        private readonly IMapper _mapper;

        public ConceptoCalificacionRegisterHandler(IRepositoryConceptoCalificacion repositoryConceptoCalificacion, IMapper mapper)
        {
            _repositoryConceptoCalificacion = repositoryConceptoCalificacion;
            _mapper = mapper;
        }

        public async Task<ConceptoCalificacionDto> Handle(ConceptoCalificacionRegisterCommand request, CancellationToken cancellationToken)
        {
            // Validar si el nombre ya existe en la base de datos
            var conceptoExistente = await _repositoryConceptoCalificacion.TraerUnoAsync(x => x.Nombre == request.Nombre);
            if (conceptoExistente != null)
            {
                throw new InvalidOperationException("El concepto de calificación ya está registrado.");
            }

            // Crear la nueva entidad ConceptoCalificacion
            var nuevoConceptoCalificacion = new JRWork.Administracion.DataAccess.Models.ConceptoCalificacion
            {
                ConceptoCalificacionId = request.ConceptoCalificacionId,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
            };

            // Añadir la nueva entidad a la base de datos
            var conceptoInsertado = await _repositoryConceptoCalificacion.AdicionarAsync(nuevoConceptoCalificacion);

            // Mapear la entidad a un DTO
            var resultadoDto = _mapper.Map<ConceptoCalificacionDto>(conceptoInsertado);

            return resultadoDto;
        }
    }
}

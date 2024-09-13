using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.ConceptoCalificacion;

public class Registrar
{
    public class ConceptoCalificacionRegisterCommand : IRequest<ConceptoCalificacionDto>
    {
        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }
    }

    public class ConceptoCalificacionUpdateCommand : IRequest<ConceptoCalificacionDto>
    {
        public int ConceptoCalificacionId { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }
    }

    public class ConceptoCalificacionEliminarCommand : IRequest<bool>
    {
        public int ConceptoCalificacionId { get; set; }


    }
    public class ConceptoCalificacionRegisterHandler :
        IRequestHandler<ConceptoCalificacionRegisterCommand, ConceptoCalificacionDto>,
        IRequestHandler<ConceptoCalificacionUpdateCommand, ConceptoCalificacionDto>,
        IRequestHandler<ConceptoCalificacionEliminarCommand, bool>
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
            JRWork.Administracion.DataAccess.Models.ConceptoCalificacion? conceptoExistente = await _repositoryConceptoCalificacion.TraerUnoAsync(x => x.Nombre == request.Nombre);

            if(conceptoExistente != null)
            {
                throw new InvalidOperationException("El concepto de calificación ya está registrado.");
            }


            // Crear la nueva entidad ConceptoCalificacion
            JRWork.Administracion.DataAccess.Models.ConceptoCalificacion nuevoConceptoCalificacion = new()
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
            };

            // Añadir la nueva entidad a la base de datos
            JRWork.Administracion.DataAccess.Models.ConceptoCalificacion conceptoInsertado = await _repositoryConceptoCalificacion.AdicionarAsync(nuevoConceptoCalificacion);

            // Mapear la entidad a un DTO
            var resultadoDto = _mapper.Map<ConceptoCalificacionDto>(conceptoInsertado);

            return resultadoDto;
        }

        public async Task<ConceptoCalificacionDto> Handle(ConceptoCalificacionUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.ConceptoCalificacion? conceptoCalificacionExistente = await _repositoryConceptoCalificacion.TraerUnoAsync(x => x.ConceptoCalificacionId == request.ConceptoCalificacionId) ?? throw new InvalidOperationException("La ConceptoCalificacion no existe.");
            conceptoCalificacionExistente.Nombre = request.Nombre;
            var result = await _repositoryConceptoCalificacion.ModificarAsync(conceptoCalificacionExistente);
            return _mapper.Map<ConceptoCalificacionDto>(result);
        }

        public async Task<bool> Handle(ConceptoCalificacionEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.ConceptoCalificacion? conceptoCalificacionExistente = await _repositoryConceptoCalificacion.TraerUnoAsync(x => x.ConceptoCalificacionId == request.ConceptoCalificacionId) ?? throw new InvalidOperationException("La ConceptoCalificacion no existe.");
            return await _repositoryConceptoCalificacion.EliminarAsync(conceptoCalificacionExistente);
        }
    }
}

using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Oficio;

public class Registrar
{
    public class OficioRegisterCommand : IRequest<OficioDto>
    {
        public string? Nombre { get; set; }

        public int? AreaId { get; set; }
    }
    public class OficioUpdateCommand : IRequest<OficioDto>
    {
        public int OficioId { get; set; }

        public string? Nombre { get; set; }

        public int? AreaId { get; set; }
    }
    public class OficioEliminarCommand : IRequest<bool>
    {
        public int OficioId { get; set; }

    }
    public class OficioRegisterHandler : IRequestHandler<OficioRegisterCommand, OficioDto>,
        IRequestHandler<OficioUpdateCommand,OficioDto>,
        IRequestHandler<OficioEliminarCommand,bool>
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
            JRWork.Administracion.DataAccess.Models.Oficio? oficioExistente = await _repositoryOficio.TraerUnoAsync(x => x.Nombre == request.Nombre);
            
            if(oficioExistente != null)
            {
                throw new InvalidOperationException("La Oficio ya está registrada."); ;

            }

            JRWork.Administracion.DataAccess.Models.Oficio actividad = new()
            {
                Nombre = request.Nombre,
                AreaId = request.AreaId
            };

            JRWork.Administracion.DataAccess.Models.Oficio result = await _repositoryOficio.AdicionarAsync(actividad);

            return _mapper.Map<OficioDto>(result);
        }

        public async Task<OficioDto> Handle(OficioUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Oficio? oficioExistente = await _repositoryOficio.TraerUnoAsync(x => x.OficioId == request.OficioId) ?? throw new InvalidOperationException("La actividad no existe.");
            oficioExistente.Nombre = request.Nombre;
            oficioExistente.AreaId = request.AreaId;
            var result = await _repositoryOficio.ModificarAsync(oficioExistente);
            return _mapper.Map<OficioDto>(result);
        }

        public async Task<bool> Handle(OficioEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Oficio? oficioExistente = await _repositoryOficio.TraerUnoAsync(x => x.OficioId == request.OficioId) ?? throw new InvalidOperationException("La Oficio no existe.");
            return await _repositoryOficio.EliminarAsync(oficioExistente);
        }
    }
}

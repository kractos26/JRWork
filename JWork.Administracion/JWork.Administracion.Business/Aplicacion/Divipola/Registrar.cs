using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.Divipola;
public class Registrar
{
    public class DivipolaRegisterCommand : IRequest<DivipolaDto>
    {

        public decimal Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal? CodigoPadre { get; set; }
    }

    public class DivipolaUpdateCommand : IRequest<DivipolaDto>
    {
        public int DivipolaId { get; set; }

        public decimal Codigo { get; set; }

        public string Nombre { get; set; } = null!;

        public decimal? CodigoPadre { get; set; }
    }

    public class DivipolaEliminarCommand : IRequest<bool>
    {
        public int DivipolaId { get; set; }
    }
    public class DivipolaRegisterHandler : IRequestHandler<DivipolaRegisterCommand, DivipolaDto>
        , IRequestHandler<DivipolaUpdateCommand, DivipolaDto>
        , IRequestHandler<DivipolaEliminarCommand, bool>
    {
        private readonly IRepositoryDivipola _repositoryDivipola;
        private readonly IMapper _mapper;

        public DivipolaRegisterHandler(IRepositoryDivipola repositoryDivipola, IMapper mapper)
        {
            _repositoryDivipola = repositoryDivipola;
            _mapper = mapper;
        }

        public async Task<DivipolaDto> Handle(DivipolaRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Divipola? divipolaExistente = await _repositoryDivipola.TraerUnoAsync(x => x.Nombre == request.Nombre) ?? throw new InvalidOperationException("El Divipola ya está registrada.");

            JRWork.Administracion.DataAccess.Models.Divipola actividad = new()
            {
                Nombre = request.Nombre,
                Codigo = request.Codigo,
                CodigoPadre = request.CodigoPadre
            };

            JRWork.Administracion.DataAccess.Models.Divipola result = await _repositoryDivipola.AdicionarAsync(actividad);

            return _mapper.Map<DivipolaDto>(result);
        }

        async Task<bool> IRequestHandler<DivipolaEliminarCommand, bool>.Handle(DivipolaEliminarCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Divipola? divipolaExistente = await _repositoryDivipola.TraerUnoAsync(x => x.DivipolaId == request.DivipolaId) ?? throw new InvalidOperationException("La Divipola no existe.");
            return await _repositoryDivipola.EliminarAsync(divipolaExistente);
        }

        async Task<DivipolaDto> IRequestHandler<DivipolaUpdateCommand, DivipolaDto>.Handle(DivipolaUpdateCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.Divipola? divipolaExistente = await _repositoryDivipola.TraerUnoAsync(x => x.DivipolaId == request.DivipolaId) ?? throw new InvalidOperationException("La actividad no existe.");
            divipolaExistente.Nombre = request.Nombre;
            divipolaExistente.CodigoPadre = request.CodigoPadre;
            divipolaExistente.Codigo = request.Codigo;
            var result = await _repositoryDivipola.ModificarAsync(divipolaExistente);
            return _mapper.Map<DivipolaDto>(result);
        }
    }

}
﻿using AutoMapper;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using JWork.Administracion.Dto;
using MediatR;

namespace JWork.Administracion.Business.Aplicacion.UnidadMedida;

public class Registrar
{
    public class UnidadMedidaRegisterCommand : IRequest<UnidadMedidaDto>
    {
        public int UnidadMedidaId { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class UnidadMedidaRegisterHandler : IRequestHandler<UnidadMedidaRegisterCommand, UnidadMedidaDto>
    {
        private readonly IRepositoryUnidadMedida _repositoryUnidadMedida;
        private readonly IMapper _mapper;

        public UnidadMedidaRegisterHandler(IRepositoryUnidadMedida repositoryUnidadMedida, IMapper mapper)
        {
            _repositoryUnidadMedida = repositoryUnidadMedida;
            _mapper = mapper;
        }

        public async Task<UnidadMedidaDto> Handle(UnidadMedidaRegisterCommand request, CancellationToken cancellationToken)
        {
            JRWork.Administracion.DataAccess.Models.UnidadMedida? actividadExistente = await _repositoryUnidadMedida.TraerUnoAsync(x => x.Nombre == request.Nombre);
            if (actividadExistente != null)
            {
                throw new InvalidOperationException("La UnidadMedida ya está registrada.");
            }

            JRWork.Administracion.DataAccess.Models.UnidadMedida actividad = new()
            {
                Nombre = request.Nombre,
                UnidadMedidaId = request.UnidadMedidaId
            };

            JRWork.Administracion.DataAccess.Models.UnidadMedida result = await _repositoryUnidadMedida.AdicionarAsync(actividad);

            return _mapper.Map<UnidadMedidaDto>(result);
        }
    }
}

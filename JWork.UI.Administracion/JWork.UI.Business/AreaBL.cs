﻿using AutoMapper;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business;

public class AreaBL(IRepositoryArea repository, IMapper mapper)
{
    private readonly IRepositoryArea _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<AreaDto> Crear(AreaDto request)
    {
        Area entidad = _mapper.Map<Area>(request);
        if (request.Nombre == null)
        {
            throw new JWorkException("Ingresa la área");
        }
        Area? exist = await _repository.TraerUnoAsync(x => x.Nombre.ToLower() == request.Nombre.ToLower());
        if (exist == null)
        {
            await _repository.AdicionarAsync(entidad);
        }
        else
        {
            throw new JWorkException("EL área ya se encuentra creada");
        }
        return _mapper.Map<AreaDto>(entidad);
    }

    public async Task<AreaDto> Modificar(AreaDto request)
    {
        string mensaje = "El área no existe";

        if (request.AreaId <= 0)
        {
            throw new JWorkException(mensaje);
        }
        Area? entidad = await _repository.TraerUnoAsync(x => x.AreaId == request.AreaId);
        if (entidad != null)
        {
            _mapper.Map(request, entidad);
            await _repository.ModificarAsync(entidad);
        }
        return _mapper.Map<AreaDto>(entidad);
    }


    public async Task<List<AreaDto>> Buscar(PaginadoRequest<AreaDto> request)
    {
        List<Area> buscar = await _repository.BuscarPaginadoAsync(
    x => x.AreaId == (request.Entidad.AreaId > 0 ? request.Entidad.AreaId : x.AreaId) &&
         (string.IsNullOrEmpty(request.Entidad.Nombre) || x.Nombre.ToLower().Contains(request.Entidad.Nombre.ToLower())),
    request.NumeroPagina, request.TotalRegistros);

        if (buscar.Count > 0)
        {
            return _mapper.Map<List<AreaDto>>(buscar);
        }
        throw new JWorkException("Registros no encontrados");

    }

    public async Task<AreaDto> GetPorIdAsync(int actividadId)
    {
        Area? actividad = await _repository.TraerUnoAsync(x => x.AreaId == actividadId);
        return _mapper.Map<AreaDto>(actividad);
    }
}


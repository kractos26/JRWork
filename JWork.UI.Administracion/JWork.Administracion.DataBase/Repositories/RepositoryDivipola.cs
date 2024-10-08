﻿using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class RepositoryDivipola(IRepositorio<Divipola> repocitorio) : IRepositoryDivipola
{
    private readonly IRepositorio<Divipola> _repocitorio = repocitorio;

    public async Task<Divipola> AdicionarAsync(Divipola Entidad) => await _repocitorio.AdicionarAsync(Entidad);


    public async Task<List<Divipola>> BuscarAsync(Expression<Func<Divipola, bool>> predicado) => await _repocitorio.BuscarAsync(predicado);

    public Task<List<Divipola>> BuscarPaginadoAsync(Expression<Func<Divipola, bool>> predicado, int numeroPagina, int tamanoPagina) => _repocitorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);


    public async Task<bool> EliminarAsync(Divipola Entidad) => await _repocitorio.EliminarAsync(Entidad);


    public async Task<List<Divipola>> GetAllAsync() => await _repocitorio.GetAllAsync();


    public async Task GuardarAsync() => await _repocitorio.GuardarAsync();


    public async Task<Divipola> ModificarAsync(Divipola Entidad) => await _repocitorio.ModificarAsync(Entidad);


    public async Task<Divipola?> TraerUltimoAsync(Expression<Func<Divipola, bool>> predicado) => await _repocitorio.TraerUltimoAsync(predicado);


    public async Task<Divipola?> TraerUnoAsync(Expression<Func<Divipola, bool>> predicado) => await _repocitorio.TraerUnoAsync(predicado);

}

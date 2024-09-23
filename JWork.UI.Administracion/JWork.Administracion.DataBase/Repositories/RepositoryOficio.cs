using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class RepositoryOficio : IRepositoryOficio
{
    private readonly IRepositorio<Oficio> _repositorio;
    public RepositoryOficio(IRepositorio<Oficio> repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Oficio> AdicionarAsync(Oficio Entidad) => await _repositorio.AdicionarAsync(Entidad);
    public Task<List<Oficio>> BuscarPaginadoAsync(Expression<Func<Oficio, bool>> predicado, int numeroPagina, int tamanoPagina) => _repositorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);


    public async Task<List<Oficio>> BuscarAsync(Expression<Func<Oficio, bool>> predicado) => await _repositorio.BuscarAsync(predicado);


    public async Task<bool> EliminarAsync(Oficio Entidad) => await _repositorio.EliminarAsync(Entidad);


    public async Task<List<Oficio>> GetAllAsync() => await _repositorio.GetAllAsync();


    public async Task GuardarAsync() => await _repositorio.GuardarAsync();


    public async Task<Oficio> ModificarAsync(Oficio Entidad) => await _repositorio.ModificarAsync(Entidad);


    public async Task<Oficio?> TraerUltimoAsync(Expression<Func<Oficio, bool>> predicado) => await _repositorio.TraerUltimoAsync(predicado);


    public async Task<Oficio?> TraerUnoAsync(Expression<Func<Oficio, bool>> predicado) => await _repositorio.TraerUnoAsync(predicado);

}


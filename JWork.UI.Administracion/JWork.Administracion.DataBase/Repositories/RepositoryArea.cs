using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class RepositoryArea(IRepositorio<Area> repocitorio) : IRepositoryArea
{
    private readonly IRepositorio<Area> _repocitorio = repocitorio;

    public async Task<Area> AdicionarAsync(Area Entidad) => await _repocitorio.AdicionarAsync(Entidad);

    public Task<List<Area>> BuscarPaginadoAsync(Expression<Func<Area, bool>> predicado, int numeroPagina, int tamanoPagina) => _repocitorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);

    public async Task<List<Area>> BuscarAsync(Expression<Func<Area, bool>> predicado) => await _repocitorio.BuscarAsync(predicado);

    public async Task<bool> EliminarAsync(Area Entidad) => await _repocitorio.EliminarAsync(Entidad);


    public async Task<List<Area>> GetAllAsync() => await _repocitorio.GetAllAsync();


    public async Task GuardarAsync() => await _repocitorio.GuardarAsync();


    public async Task<Area> ModificarAsync(Area Entidad) => await _repocitorio.ModificarAsync(Entidad);


    public async Task<Area?> TraerUltimoAsync(Expression<Func<Area, bool>> predicado) => await _repocitorio.TraerUltimoAsync(predicado);


    public async Task<Area?> TraerUnoAsync(Expression<Func<Area, bool>> predicado) => await _repocitorio.TraerUnoAsync(predicado);

}

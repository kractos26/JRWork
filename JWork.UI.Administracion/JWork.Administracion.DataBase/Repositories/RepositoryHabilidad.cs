using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class RepositoryHabilidad : IRepositoryHabilidad
{
    private readonly IRepositorio<Habilidad> _repositorio;
    public RepositoryHabilidad(IRepositorio<Habilidad> repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<Habilidad> AdicionarAsync(Habilidad Entidad) => await _repositorio.AdicionarAsync(Entidad);

    public Task<List<Habilidad>> BuscarPaginadoAsync(Expression<Func<Habilidad, bool>> predicado, int numeroPagina, int tamanoPagina) => _repositorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);


    public async Task<List<Habilidad>> BuscarAsync(Expression<Func<Habilidad, bool>> predicado) => await _repositorio.BuscarAsync(predicado);
    

    public async Task<bool> EliminarAsync(Habilidad Entidad) => await _repositorio.EliminarAsync(Entidad);
   

    public async Task<List<Habilidad>> GetAllAsync() => await _repositorio.GetAllAsync();
    

    public async Task GuardarAsync() => await _repositorio.GuardarAsync();
    

    public async Task<Habilidad> ModificarAsync(Habilidad Entidad) => await _repositorio.ModificarAsync(Entidad);
    

    public async Task<Habilidad?> TraerUltimoAsync(Expression<Func<Habilidad, bool>> predicado) => await _repositorio.TraerUltimoAsync(predicado);


    public async Task<Habilidad?> TraerUnoAsync(Expression<Func<Habilidad, bool>> predicado) => await _repositorio.TraerUnoAsync(predicado);
    
}

using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories;

public class RepositoryDivipola : IRepositoryDivipola
{
    private readonly IRepositorio<Divipola> _repocitorio;
    public RepositoryDivipola(IRepositorio<Divipola> repocitorio)
    {
        _repocitorio = repocitorio;
    }
    public async Task<Divipola> AdicionarAsync(Divipola Entidad) => await _repocitorio.AdicionarAsync(Entidad);


    public async Task<List<Divipola>> BuscarAsync(Expression<Func<Divipola, bool>> predicado) => await _repocitorio.BuscarAsync(predicado);

    public async Task<bool> EliminarAsync(Divipola Entidad) => await _repocitorio.EliminarAsync(Entidad);


    public async Task<List<Divipola>> GetAllAsync() => await _repocitorio.GetAllAsync();


    public async Task GuardarAsync() => await _repocitorio.GuardarAsync();


    public async Task<Divipola> ModificarAsync(Divipola Entidad) => await _repocitorio.ModificarAsync(Entidad);


    public async Task<Divipola?> TraerUltimoAsync(Expression<Func<Divipola, bool>> predicado) => await _repocitorio.TraerUltimoAsync(predicado);


    public async Task<Divipola?> TraerUnoAsync(Expression<Func<Divipola, bool>> predicado) => await _repocitorio.TraerUnoAsync(predicado);

}

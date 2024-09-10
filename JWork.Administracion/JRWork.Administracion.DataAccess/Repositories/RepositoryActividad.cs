using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories;

public class RepositoryActividad : IRepositoryActividad
{
    private readonly IRepositorio<Actividad> _repocitorio;
    public RepositoryActividad(IRepositorio<Actividad> repocitorio)
    {
        _repocitorio = repocitorio;
    }

    public async Task<Actividad> AdicionarAsync(Actividad entidad) => await _repocitorio.AdicionarAsync(entidad);
    

    public async Task<List<Actividad>> BuscarAsync(Expression<Func<Actividad, bool>> predicado) => await _repocitorio.BuscarAsync(predicado);
    

    public async Task<bool> EliminarAsync(Actividad entidad) => await _repocitorio.EliminarAsync(entidad);
    

    public async Task<List<Actividad>> GetAllAsync() => await _repocitorio.GetAllAsync();
    

    public async Task GuardarAsync() => await _repocitorio.GuardarAsync();
    

    public  async Task<Actividad> ModificarAsync(Actividad entidad) => await _repocitorio.ModificarAsync(entidad);
    

    public Task<Actividad?> TraerUltimoAsync(Expression<Func<Actividad, bool>> predicado) => _repocitorio.TraerUnoAsync(predicado);


    public Task<Actividad?> TraerUnoAsync(Expression<Func<Actividad, bool>> predicado) => _repocitorio.TraerUnoAsync(predicado);

    
}

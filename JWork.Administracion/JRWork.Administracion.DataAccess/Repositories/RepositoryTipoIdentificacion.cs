using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories;

public class RepositoryTipoIdentificacion : IRepositoryTipoIdentificacion
{
    private readonly IRepositorio<TipoIdentificacion> _repocitorio;
    public RepositoryTipoIdentificacion(IRepositorio<TipoIdentificacion> repocitorio)
    {
        _repocitorio = repocitorio;
    }

    public async Task<TipoIdentificacion> AdicionarAsync(TipoIdentificacion entidad) => await _repocitorio.AdicionarAsync(entidad);
    

    public async Task<List<TipoIdentificacion>> BuscarAsync(Expression<Func<TipoIdentificacion, bool>> predicado) => await _repocitorio.BuscarAsync(predicado);
    

    public async Task<bool> EliminarAsync(TipoIdentificacion entidad) => await _repocitorio.EliminarAsync(entidad);
    

    public async Task<List<TipoIdentificacion>> GetAllAsync() => await _repocitorio.GetAllAsync();
    

    public async Task GuardarAsync() => await _repocitorio.GuardarAsync();
    

    public  async Task<TipoIdentificacion> ModificarAsync(TipoIdentificacion entidad) => await _repocitorio.ModificarAsync(entidad);
    

    public Task<TipoIdentificacion?> TraerUltimoAsync(Expression<Func<TipoIdentificacion, bool>> predicado) => _repocitorio.TraerUnoAsync(predicado);


    public Task<TipoIdentificacion?> TraerUnoAsync(Expression<Func<TipoIdentificacion, bool>> predicado) => _repocitorio.TraerUnoAsync(predicado);

    
}

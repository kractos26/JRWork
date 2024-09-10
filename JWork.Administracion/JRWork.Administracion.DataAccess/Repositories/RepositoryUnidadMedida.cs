using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories;

public class RepositoryUnidadMedida : IRepositoryUnidadMedida
{
    private readonly IRepositorio<UnidadMedida> _repositorio;
    public RepositoryUnidadMedida(IRepositorio<UnidadMedida> repositorio)
    {
        _repositorio = repositorio;
    }
    public async Task<UnidadMedida> AdicionarAsync(UnidadMedida Entidad) => await _repositorio.AdicionarAsync(Entidad);


    public async Task<List<UnidadMedida>> BuscarAsync(Expression<Func<UnidadMedida, bool>> predicado) => await _repositorio.BuscarAsync(predicado);


    public async Task<bool> EliminarAsync(UnidadMedida Entidad) => await _repositorio.EliminarAsync(Entidad);

    public async Task<List<UnidadMedida>> GetAllAsync() => await _repositorio.GetAllAsync();


    public async Task GuardarAsync() => await _repositorio.GuardarAsync();


    public async Task<UnidadMedida> ModificarAsync(UnidadMedida Entidad) => await _repositorio.ModificarAsync(Entidad);


    public async Task<UnidadMedida?> TraerUltimoAsync(Expression<Func<UnidadMedida, bool>> predicado) => await _repositorio.TraerUltimoAsync(predicado);



    public async Task<UnidadMedida?> TraerUnoAsync(Expression<Func<UnidadMedida, bool>> predicado) => await _repositorio.TraerUnoAsync(predicado);
}

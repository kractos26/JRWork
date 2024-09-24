
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class RepositoryActividad(IRepositorio<Actividad> repocitorio) : IRepositoryActividad
{
    public async Task<Actividad> AdicionarAsync(Actividad entidad) => await repocitorio.AdicionarAsync(entidad);


    public async Task<List<Actividad>> BuscarAsync(Expression<Func<Actividad, bool>> predicado) => await repocitorio.BuscarAsync(predicado);

    public Task<List<Actividad>> BuscarPaginadoAsync(Expression<Func<Actividad, bool>> predicado, int numeroPagina, int tamanoPagina) => repocitorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);


    public async Task<bool> EliminarAsync(Actividad entidad) => await repocitorio.EliminarAsync(entidad);


    public async Task<List<Actividad>> GetAllAsync() => await repocitorio.GetAllAsync();


    public async Task GuardarAsync() => await repocitorio.GuardarAsync();


    public async Task<Actividad> ModificarAsync(Actividad entidad) => await repocitorio.ModificarAsync(entidad);


    public Task<Actividad?> TraerUltimoAsync(Expression<Func<Actividad, bool>> predicado) => repocitorio.TraerUnoAsync(predicado);


    public Task<Actividad?> TraerUnoAsync(Expression<Func<Actividad, bool>> predicado) => repocitorio.TraerUnoAsync(predicado);


}

using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class RepositoryTipoDocumento(IRepositorio<TipoDocumento> repositorio) : IRepositoryTipoDocumento
{
    public async Task<TipoDocumento> AdicionarAsync(TipoDocumento Entidad) => await repositorio.AdicionarAsync(Entidad);
    public Task<List<TipoDocumento>> BuscarPaginadoAsync(Expression<Func<TipoDocumento, bool>> predicado, int numeroPagina, int tamanoPagina) => repositorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);


    public async Task<List<TipoDocumento>> BuscarAsync(Expression<Func<TipoDocumento, bool>> predicado) => await repositorio.BuscarAsync(predicado);
    

    public async Task<bool> EliminarAsync(TipoDocumento Entidad) => await repositorio.EliminarAsync(Entidad);
   

    public async Task<List<TipoDocumento>> GetAllAsync() => await repositorio.GetAllAsync();
    

    public async Task GuardarAsync() => await repositorio.GuardarAsync();
   

    public Task<TipoDocumento> ModificarAsync(TipoDocumento Entidad) => repositorio.ModificarAsync(Entidad);


    public async Task<TipoDocumento?> TraerUltimoAsync(Expression<Func<TipoDocumento, bool>> predicado) => await repositorio.TraerUltimoAsync(predicado);


    public async Task<TipoDocumento?> TraerUnoAsync(Expression<Func<TipoDocumento, bool>> predicado) => await repositorio.TraerUnoAsync(predicado);
  
}

using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class RepositoryConceptoCalificacion(IRepositorio<ConceptoCalificacion> repositorio) : IRepositoryConceptoCalificacion
{
    public async Task<ConceptoCalificacion> AdicionarAsync(ConceptoCalificacion Entidad) => await repositorio.AdicionarAsync(Entidad);

    public Task<List<ConceptoCalificacion>> BuscarPaginadoAsync(Expression<Func<ConceptoCalificacion, bool>> predicado, int numeroPagina, int tamanoPagina) => repositorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);

    public async Task<List<ConceptoCalificacion>> BuscarAsync(Expression<Func<ConceptoCalificacion, bool>> predicado) => await repositorio.BuscarAsync(predicado);


    public async Task<bool> EliminarAsync(ConceptoCalificacion Entidad) => await repositorio.EliminarAsync(Entidad);


    public async Task<List<ConceptoCalificacion>> GetAllAsync() => await repositorio.GetAllAsync();


    public async Task GuardarAsync() => await repositorio.GuardarAsync();


    public async Task<ConceptoCalificacion> ModificarAsync(ConceptoCalificacion Entidad) => await repositorio.ModificarAsync(Entidad);


    public async Task<ConceptoCalificacion?> TraerUltimoAsync(Expression<Func<ConceptoCalificacion, bool>> predicado) => await repositorio.TraerUltimoAsync(predicado);


    public async Task<ConceptoCalificacion?> TraerUnoAsync(Expression<Func<ConceptoCalificacion, bool>> predicado) => await repositorio.TraerUnoAsync(predicado);

}
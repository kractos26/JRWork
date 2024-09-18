

using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories;

public class RepositoryConceptoCalificacion : IRepositoryConceptoCalificacion
{
    private readonly IRepositorio<ConceptoCalificacion> _repositorio;
    public RepositoryConceptoCalificacion(IRepositorio<ConceptoCalificacion> repositorio)
    {
        _repositorio = repositorio;
    }

    public async Task<ConceptoCalificacion> AdicionarAsync(ConceptoCalificacion Entidad) => await _repositorio.AdicionarAsync(Entidad);

    public Task<List<ConceptoCalificacion>> BuscarPaginadoAsync(Expression<Func<ConceptoCalificacion, bool>> predicado, int numeroPagina, int tamanoPagina) => _repositorio.BuscarPaginadoAsync(predicado, numeroPagina, tamanoPagina);

    public async Task<List<ConceptoCalificacion>> BuscarAsync(Expression<Func<ConceptoCalificacion, bool>> predicado) => await _repositorio.BuscarAsync(predicado);


    public async Task<bool> EliminarAsync(ConceptoCalificacion Entidad) => await _repositorio.EliminarAsync(Entidad);


    public async Task<List<ConceptoCalificacion>> GetAllAsync() => await _repositorio.GetAllAsync();


    public async Task GuardarAsync() => await _repositorio.GuardarAsync();


    public async Task<ConceptoCalificacion> ModificarAsync(ConceptoCalificacion Entidad) => await _repositorio.ModificarAsync(Entidad);


    public async Task<ConceptoCalificacion?> TraerUltimoAsync(Expression<Func<ConceptoCalificacion, bool>> predicado) => await _repositorio.TraerUltimoAsync(predicado);


    public async Task<ConceptoCalificacion?> TraerUnoAsync(Expression<Func<ConceptoCalificacion, bool>> predicado) => await _repositorio.TraerUnoAsync(predicado);

}
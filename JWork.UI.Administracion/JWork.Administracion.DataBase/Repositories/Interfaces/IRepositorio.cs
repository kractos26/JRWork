﻿using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories.Interfaces;

public interface IRepositorio<T> where T : class
{
    Task<List<T>> GetAllAsync();

    Task<List<T>> BuscarAsync(Expression<Func<T, bool>> predicado);

    Task<T?> TraerUnoAsync(Expression<Func<T, bool>> predicado);

    Task<T?> TraerUltimoAsync(Expression<Func<T, bool>> predicado);

    Task<T> AdicionarAsync(T Entidad);

    Task<T> ModificarAsync(T Entidad);

    Task<bool> EliminarAsync(T Entidad);

    Task<List<T>> BuscarPaginadoAsync(Expression<Func<T, bool>> predicado, int numeroPagina, int tamanoPagina);

    Task GuardarAsync();
}

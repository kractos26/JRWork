using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JWork.UI.Administracion.DataBase.Repositories;

public class Repositorio<T>(JWorkContext contex) : IRepositorio<T>, IDisposable where T : class
{
    private readonly JWorkContext _context = contex;

    public async Task<T> AdicionarAsync(T Entidad)
    {
        if (_context.Entry(Entidad).State != EntityState.Deleted)
        {
            _context.Entry(Entidad).State = EntityState.Added;
        }
        else
        {
            _context.Set<T>().Add(Entidad);
        }
        await _context.SaveChangesAsync();
        return Entidad;
    }

    public Task<List<T>> BuscarAsync(Expression<Func<T, bool>> predicado) => _context.Set<T>().Where(predicado).ToListAsync();

    public void Dispose() => GC.SuppressFinalize(this);

    public async Task<bool> EliminarAsync(T Entidad)
    {
        if (_context.Entry(Entidad).State == EntityState.Deleted)
        { _context.Set<T>().Attach(Entidad); }
        _context.Entry(Entidad).State = EntityState.Deleted;
       return await _context.SaveChangesAsync() > 0;
    }

    public Task<List<T>> GetAllAsync() => _context.Set<T>().ToListAsync();


    public Task GuardarAsync() => _context.SaveChangesAsync();


    public async Task<T> ModificarAsync(T Entidad)
    {
        if (this._context.Entry(Entidad).State == EntityState.Deleted)
        { this._context.Set<T>().Attach(Entidad); }

        _context.Entry(Entidad).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return Entidad;
    }

    public Task<T?> TraerUnoAsync(Expression<Func<T, bool>> predicado) => _context.Set<T>().FirstOrDefaultAsync(predicado);


    public Task<T?> TraerUltimoAsync(Expression<Func<T, bool>> predicado) => _context.Set<T>().LastOrDefaultAsync(predicado);

    public async Task<List<T>> BuscarPaginadoAsync(Expression<Func<T, bool>> predicado, int numeroPagina, int tamanoPagina)
    {
        return await _context.Set<T>()
                             .Where(predicado)
                             .Skip((numeroPagina - 1) * tamanoPagina)
                             .Take(tamanoPagina)
                             .ToListAsync();
    }

}

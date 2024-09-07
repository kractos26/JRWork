using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories
{
    public class Repositorio<T> : IRepositorio<T>, IDisposable where T : class
    {
        private readonly DbContext _contex;
        public Repositorio(DbContext contex)
        {
            this._contex = contex;

        }

        public async Task<T> AdicionarAsync(T Entidad)
        {
            if (this._contex.Entry(Entidad).State != EntityState.Deleted)
            {
                this._contex.Entry(Entidad).State = EntityState.Added;
            }
            else
            {
                _contex.Set<T>().Add(Entidad);
                await _contex.SaveChangesAsync();
            }
            return Entidad;
        }

        public Task<List<T>> BuscarAsync(Expression<Func<T, bool>> predicado) => _contex.Set<T>().Where(predicado).ToListAsync();

        public void Dispose() => GC.SuppressFinalize(this);

        public async Task<T> EliminarAsync(T Entidad)
        {
            if (_contex.Entry(Entidad).State == EntityState.Deleted)
            { _contex.Set<T>().Attach(Entidad); }
            _contex.Entry(Entidad).State = EntityState.Deleted;
            await _contex.SaveChangesAsync();
            return Entidad;
        }

        public Task<List<T>> GetAllAsync() => _contex.Set<T>().ToListAsync();


        public Task GuardarAsync() => _contex.SaveChangesAsync();


        public async Task<T> ModificarAsync(T Entidad)
        {
            if (this._contex.Entry(Entidad).State == EntityState.Deleted)
            { this._contex.Set<T>().Attach(Entidad); }

            _contex.Entry(Entidad).State = EntityState.Modified;
            await _contex.SaveChangesAsync();
            return Entidad;
        }

        public Task<T?> TraerUnoAsync(Expression<Func<T, bool>> predicado) => _contex.Set<T>().FirstOrDefaultAsync(predicado);


        public Task<T?> TraerUltimoAsync(Expression<Func<T, bool>> predicado) => _contex.Set<T>().LastOrDefaultAsync(predicado);

    }

}

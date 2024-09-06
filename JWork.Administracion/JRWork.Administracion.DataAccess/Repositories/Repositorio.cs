using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

        public T Adicionar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State != EntityState.Deleted)
            {
                this._contex.Entry<T>(Entidad).State = EntityState.Added;
            }
            else
            {
                this._contex.Set<T>().Add(Entidad);
            }
            return Entidad;
        }

        public List<T> Buscar(Expression<Func<T, bool>> predicado) => _contex.Set<T>().Where(predicado).ToList();
        
        public void Dispose() => GC.SuppressFinalize(this);

        public T Eliminar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State == EntityState.Deleted)
            { this._contex.Set<T>().Attach(Entidad); }
            _contex.Entry<T>(Entidad).State = EntityState.Deleted;
            return Entidad;
        }

        public List<T> GetAll() => _contex.Set<T>().ToList();
       

        public void Guardar() => this._contex.SaveChanges();
        

        public T Modificar(T Entidad)
        {
            if (this._contex.Entry<T>(Entidad).State == EntityState.Deleted)
            { this._contex.Set<T>().Attach(Entidad); }

            _contex.Entry<T>(Entidad).State = EntityState.Modified;

            return Entidad;
        }

        public T? TraerUno(Expression<Func<T, bool>> predicado)
        {
            T? result  =  _contex.Set<T>().FirstOrDefault(predicado);
            return result ?? default;
            
        }

        public T? TraerUltimo(Expression<Func<T, bool>> predicado)
        {
            return _contex.Set<T>().LastOrDefault(predicado);         }
    }
}


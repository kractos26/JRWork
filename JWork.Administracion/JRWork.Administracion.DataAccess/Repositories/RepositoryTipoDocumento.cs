using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories
{
    internal class RepositoryTipoDocumento : IRepositoryTipoDocumento
    {
        public TipoDocumento Adicionar(TipoDocumento Entidad)
        {
            throw new NotImplementedException();
        }

        public List<TipoDocumento> Buscar(Expression<Func<TipoDocumento, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public TipoDocumento Eliminar(TipoDocumento Entidad)
        {
            throw new NotImplementedException();
        }

        public List<TipoDocumento> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public TipoDocumento Modificar(TipoDocumento Entidad)
        {
            throw new NotImplementedException();
        }

        public TipoDocumento? TraerUltimo(Expression<Func<TipoDocumento, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public TipoDocumento? TraerUno(Expression<Func<TipoDocumento, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}

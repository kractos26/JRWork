using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories
{
    public class RepositoryArea : IRepositoryArea
    {
        public Area Adicionar(Area Entidad)
        {
            throw new NotImplementedException();
        }

        public List<Area> Buscar(Expression<Func<Area, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public Area Eliminar(Area Entidad)
        {
            throw new NotImplementedException();
        }

        public List<Area> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Guardar()
        {
            throw new NotImplementedException();
        }

        public Area Modificar(Area Entidad)
        {
            throw new NotImplementedException();
        }

        public Area? TraerUltimo(Expression<Func<Area, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public Area? TraerUno(Expression<Func<Area, bool>> predicado)
        {
            throw new NotImplementedException();
        }
    }
}

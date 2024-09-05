

using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories.Interfaces
{
    public interface IRepositorio<T> where T : class
    {
        List<T> GetAll();

        List<T> Buscar(Expression<Func<T, bool>> predicado);

        T? TraerUno(Expression<Func<T, bool>> predicado);

        T? TraerUltimo(Expression<Func<T, bool>> predicado);

        T Adicionar(T Entidad);

        T Modificar(T Entidad);

        T Eliminar(T Entidad);

        void Guardar();
    }
}

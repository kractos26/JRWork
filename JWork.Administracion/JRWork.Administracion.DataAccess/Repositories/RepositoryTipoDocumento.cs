using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories
{
    public class RepositoryTipoDocumento : IRepositoryTipoDocumento
    {
        private readonly IRepositorio<TipoDocumento> _repositorio;
        public RepositoryTipoDocumento(IRepositorio<TipoDocumento> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<TipoDocumento> AdicionarAsync(TipoDocumento Entidad) => await _repositorio.AdicionarAsync(Entidad);
       

        public async Task<List<TipoDocumento>> BuscarAsync(Expression<Func<TipoDocumento, bool>> predicado) => await _repositorio.BuscarAsync(predicado);
        

        public async Task<TipoDocumento> EliminarAsync(TipoDocumento Entidad) => await _repositorio.EliminarAsync(Entidad);
       

        public async Task<List<TipoDocumento>> GetAllAsync() => await _repositorio.GetAllAsync();
        

        public async Task GuardarAsync() => await _repositorio.GuardarAsync();
       

        public Task<TipoDocumento> ModificarAsync(TipoDocumento Entidad) => _repositorio.ModificarAsync(Entidad);


        public async Task<TipoDocumento?> TraerUltimoAsync(Expression<Func<TipoDocumento, bool>> predicado) => await _repositorio.TraerUltimoAsync(predicado);


        public async Task<TipoDocumento?> TraerUnoAsync(Expression<Func<TipoDocumento, bool>> predicado) => await _repositorio.TraerUnoAsync(predicado);
      
    }
}

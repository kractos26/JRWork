using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories
{
    public class RepositoryTipoPersona : IRepositoryTipoPersona
    {
        private readonly IRepositorio<TipoPersona> _repositorio;
        public RepositoryTipoPersona(IRepositorio<TipoPersona> repositorio)
        {
            _repositorio  = repositorio;
        }
        public async Task<TipoPersona> AdicionarAsync(TipoPersona Entidad) => await _repositorio.AdicionarAsync(Entidad);


        public async Task<List<TipoPersona>> BuscarAsync(Expression<Func<TipoPersona, bool>> predicado) => await _repositorio.BuscarAsync(predicado);
       

        public async Task<TipoPersona> EliminarAsync(TipoPersona Entidad) => await _repositorio.EliminarAsync(Entidad);

        public async Task<List<TipoPersona>> GetAllAsync() => await _repositorio.GetAllAsync(); 
        

        public async Task GuardarAsync() => await _repositorio.GuardarAsync();
        

        public async Task<TipoPersona> ModificarAsync(TipoPersona Entidad) => await _repositorio.ModificarAsync(Entidad);


        public async Task<TipoPersona?> TraerUltimoAsync(Expression<Func<TipoPersona, bool>> predicado) => await _repositorio.TraerUltimoAsync(predicado);



        public async Task<TipoPersona?> TraerUnoAsync(Expression<Func<TipoPersona, bool>> predicado) => await _repositorio.TraerUnoAsync(predicado);
        
    }
}

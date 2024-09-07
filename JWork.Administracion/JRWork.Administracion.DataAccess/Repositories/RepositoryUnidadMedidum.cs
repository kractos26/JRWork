using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories
{
    public class RepositoryUnidadMedidum : IRepositoryUnidadMedidum
    {
        private readonly IRepositorio<UnidadMedidum> _repositorio;
        public RepositoryUnidadMedidum(IRepositorio<UnidadMedidum> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<UnidadMedidum> AdicionarAsync(UnidadMedidum Entidad) => await _repositorio.AdicionarAsync(Entidad);


        public async Task<List<UnidadMedidum>> BuscarAsync(Expression<Func<UnidadMedidum, bool>> predicado) => await _repositorio.BuscarAsync(predicado);


        public async Task<UnidadMedidum> EliminarAsync(UnidadMedidum Entidad) => await _repositorio.EliminarAsync(Entidad);

        public async Task<List<UnidadMedidum>> GetAllAsync() => await _repositorio.GetAllAsync();


        public async Task GuardarAsync() => await _repositorio.GuardarAsync();


        public async Task<UnidadMedidum> ModificarAsync(UnidadMedidum Entidad) => await _repositorio.ModificarAsync(Entidad);


        public async Task<UnidadMedidum?> TraerUltimoAsync(Expression<Func<UnidadMedidum, bool>> predicado) => await _repositorio.TraerUltimoAsync(predicado);



        public async Task<UnidadMedidum?> TraerUnoAsync(Expression<Func<UnidadMedidum, bool>> predicado) => await _repositorio.TraerUnoAsync(predicado);
    }
}

﻿using JRWork.Administracion.DataAccess.Models;
using JRWork.Administracion.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;

namespace JRWork.Administracion.DataAccess.Repositories
{
    public class RepositoryArea : IRepositoryArea
    {
        private readonly IRepositorio<Area> _repocitorio;
        public RepositoryArea(IRepositorio<Area> repocitorio)
        {
            _repocitorio = repocitorio;
        }
        public async Task<Area> AdicionarAsync(Area Entidad) => await _repocitorio.AdicionarAsync(Entidad);
        

        public async Task<List<Area>> BuscarAsync(Expression<Func<Area, bool>> predicado) => await _repocitorio.BuscarAsync(predicado);

        public async Task<Area> EliminarAsync(Area Entidad) => await _repocitorio.EliminarAsync(Entidad);
       

        public async Task<List<Area>> GetAllAsync() => await _repocitorio.GetAllAsync();
        

        public async Task GuardarAsync() => await _repocitorio.GuardarAsync();
        

        public async Task<Area> ModificarAsync(Area Entidad) => await _repocitorio.ModificarAsync(Entidad);


        public async Task<Area?> TraerUltimoAsync(Expression<Func<Area, bool>> predicado) => await _repocitorio.TraerUltimoAsync(predicado);


        public async Task<Area?> TraerUnoAsync(Expression<Func<Area, bool>> predicado) => await _repocitorio.TraerUnoAsync(predicado);
        
    }
}

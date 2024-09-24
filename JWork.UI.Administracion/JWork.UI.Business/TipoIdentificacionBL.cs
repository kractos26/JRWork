using AutoMapper;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.DataBase.Repositories.Interfaces;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business
{
    public class TipoIdentificacionBL(IRepositoryTipoIdentificacion repository, IMapper mapper)
    {
        public async Task<TipoIdentificacionDto> Crear(TipoIdentificacionDto request)
        {
            TipoIdentificacion entidad = mapper.Map<TipoIdentificacion>(request);
            if (request.Nombre == null)
            {
                throw new JWorkException("El tipo de identificación ya se encuentra creado");
            }


            TipoIdentificacion? exist = await repository.TraerUnoAsync(x => x.Nombre.Equals(request.Nombre, StringComparison.CurrentCultureIgnoreCase));
            if (exist == null)
            {
                await repository.AdicionarAsync(entidad);
            }
            else
            {
                throw new JWorkException("EL Tipo de identificación ya se encuentra creado");
            }
            return mapper.Map<TipoIdentificacionDto>(entidad);
        }

        public async Task<TipoIdentificacionDto> Modificar(TipoIdentificacionDto request)
        {
            string mensaje = "El concepto de calificación no existe";

            if (request.TipoIdentificacionId <= 0)
            {
                throw new JWorkException(mensaje);
            }
            if (request.Nombre == null)
            {
                throw new JWorkException("EL tipo de identificación ya se encuentra creado");
            }

            TipoIdentificacion? entidad = await repository.TraerUnoAsync(x => x.TipoIdentificacionId == request.TipoIdentificacionId);
            if (entidad != null)
            {
                mapper.Map(request, entidad);
                await repository.ModificarAsync(entidad);
            }
            return mapper.Map<TipoIdentificacionDto>(entidad);
        }

        public async Task<List<TipoIdentificacionDto>> Buscar(PaginadoRequest<TipoIdentificacionDto> request)
        {
            List<TipoIdentificacion> buscar = await repository.BuscarPaginadoAsync(x => request.Entidad != null && x.TipoIdentificacionId == (request.Entidad.TipoIdentificacionId > 0 ? request.Entidad.TipoIdentificacionId : x.TipoIdentificacionId) && x.Nombre == (request.Entidad.Nombre ?? x.Nombre), request.NumeroPagina, request.TotalRegistros);
            if (buscar.Count > 0)
            {
                return mapper.Map<List<TipoIdentificacionDto>>(buscar);
            }
            throw new JWorkException("Registros no encontrados");

        }

        public async Task<TipoIdentificacionDto> GetPorIdAsync(int actividadId)
        {
            TipoIdentificacion? actividad = await repository.TraerUnoAsync(x => x.TipoIdentificacionId == actividadId);
            return mapper.Map<TipoIdentificacionDto>(actividad);
        }
    }
}

using AutoMapper;
using JRWork.Administracion.DataAccess.Models;
using JWork.Administracion.Dto;

namespace JWork.Administracion.Business;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Area,AreaDto>().ReverseMap();
        CreateMap<Habilidad,HabilidadDto>().ReverseMap();   
        CreateMap<Actividad,ActividadDto>().ReverseMap();
        CreateMap<TipoPersona,TipoPersonaDto>().ReverseMap();
        CreateMap<TipoDocumento,TipoDocumentoDto>().ReverseMap();
        CreateMap<UnidadMedida,UnidadMedidaDto>().ReverseMap();   
        CreateMap<Oficio,OficioDto>().ReverseMap(); 
        CreateMap<ConceptoCalificacion,ConceptoCalificacionDto>().ReverseMap();
        CreateMap<Divipola,DivipolaDto>().ReverseMap();
    }
}

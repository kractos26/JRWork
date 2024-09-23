using AutoMapper;
using JWork.UI.Administracion.DataBase.Models;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Business;

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

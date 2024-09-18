using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels;

public partial class ActividadViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    private int actividadId;

    [ObservableProperty]
    private string? nombre;

    [ObservableProperty]
    private int oficioId;

    [ObservableProperty]
    private ObservableCollection<OficioDto>? oficios;

    [ObservableProperty]
    private OficioDto oficioSeleccionado;

    private readonly ActividadBL _actividadBL;
    private readonly OficioBL _oficioBL;

    public ActividadViewModel(ActividadBL actividadBL, OficioBL oficioBL)
    {
        _actividadBL = actividadBL;
        _oficioBL = oficioBL;
        oficios = new ObservableCollection<OficioDto>();
        oficioSeleccionado = new OficioDto();
    }

    public async Task InicializarAsync()
    {
        var actividadResponse = await _actividadBL.GetPorIdAsync(oficioId); 
        if (actividadResponse?.Entidad != null)
        {
            var actividad = actividadResponse.Entidad;
            actividadId = actividad.ActividadId;
            nombre = actividad.Nombre;
            oficioId = actividad.OficioId;
            oficioSeleccionado = actividad.Oficio ?? new OficioDto();
        }

        var oficiolstResponse = await _oficioBL.GetTodoAsync();
        if (oficiolstResponse?.Entidad != null)
        {
            oficios = new ObservableCollection<OficioDto>(oficiolstResponse.Entidad);
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
        {
            oficioId = id;
        }
    }
}

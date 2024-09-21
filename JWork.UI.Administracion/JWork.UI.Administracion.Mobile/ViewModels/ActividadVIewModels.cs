using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels;

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

    [ObservableProperty]
    private string? mensajealerta;

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
        try
        {
            var actividadResponse = await _actividadBL.GetPorIdAsync(actividadId);
            if (actividadResponse != null)
            {
                ActividadDto actividad = actividadResponse;

                actividadId = actividad.ActividadId ?? 0;
                nombre = actividad.Nombre;
                oficioId = actividad.OficioId ?? 0;
                oficioSeleccionado = actividad.Oficio ?? new OficioDto();
            }

            var oficiolstResponse = await _oficioBL.Buscar(new Common.PaginadoRequest<OficioDto>()
            {
                TotalRegistros = 20,
                NumeroPagina = 1
            });
            if (oficiolstResponse.Any())
            {
                oficios = new ObservableCollection<OficioDto>(oficiolstResponse);
            }
        }
        catch(JWorkExecectioncs ex)
        {
           await GlobalAlertas.Error(ex.Message);
        }
        catch (Exception)
        {
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

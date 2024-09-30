using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels;

public partial class ActividadViewModel(ActividadBL actividadBL, OficioBL oficioBL) : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    private int actividadId;

    [ObservableProperty]
    private string? nombre;

    [ObservableProperty]
    private int oficioId;

    [ObservableProperty]
    private ObservableCollection<OficioDto>? oficios = [];

    [ObservableProperty]
    private OficioDto oficioSeleccionado = new OficioDto();

    [ObservableProperty]
    private string? mensajealerta;

    private readonly ActividadBL _actividadBL = actividadBL;
    private readonly OficioBL _oficioBL = oficioBL;

    public async Task InicializarAsync()
    {
        try
        {
            var actividadResponse = await _actividadBL.GetPorIdAsync(ActividadId);
            if (actividadResponse != null)
            {
                ActividadDto actividad = actividadResponse;

                ActividadId = actividad.ActividadId ?? 0;
                Nombre = actividad.Nombre;
                OficioId = actividad.OficioId ?? 0;
                OficioSeleccionado = actividad.Oficio ?? new OficioDto();
            }

            var oficiolstResponse = await _oficioBL.Buscar(new Common.PaginadoRequest<OficioDto>()
            {
                Entidad = new(),
                TotalRegistros = 20,
                NumeroPagina = 1
            });
            if (oficiolstResponse.Any())
            {
                Oficios = new ObservableCollection<OficioDto>(oficiolstResponse);
            }
        }
        catch (JWorkException ex)
        {
            await GlobalAlertas.Error(ex.Message);
        }
        catch (Exception)
        {
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!(!query.ContainsKey("id") || !int.TryParse(query["id"]?.ToString(), out int id)))
        {
            OficioId = id;
        }
    }
}

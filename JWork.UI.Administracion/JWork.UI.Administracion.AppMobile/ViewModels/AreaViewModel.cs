using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using static JWork.UI.Administracion.Common.Constantes;

namespace JWork.UI.Administracion.AppMobile.ViewModels;

public partial class AreaViewModel : ViewModelGlobal, IQueryAttributable
{

    private readonly AreaBL _areaBL;
    public AreaViewModel(AreaBL areaBL)
    {
        _areaBL = areaBL;
    }

    [ObservableProperty]
    public int areaId;

    [ObservableProperty]
    public string nombre;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
        {
            areaId = id;
        }
    }

    public async Task InicializarAsync()
    {
        if (areaId <= 0)
        {
            return;
        }

        try
        {
            Common.Response<AreaDto> area = await _areaBL.GetPorIdAsync(areaId);
            if (area.Status == System.Net.HttpStatusCode.OK && area.Entidad != null)
            {
                nombre = area.Entidad!.Nombre ?? string.Empty;
            }
            else
            {
                await MostrarError(area.Mensaje ?? string.Empty);
            }
        }
        catch (Exception ex)
        {
            await MostrarError($"Ocurrió un error al cargar los datos: {ex.Message}");
        }


    }

    private Task MostrarError(string mensaje)
    {
        return Task.CompletedTask;
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using static JWork.UI.Administracion.Common.Constantes;

namespace JWork.UI.Administracion.Mobile.ViewModels;

public partial class AreaViewModel : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    public int areaId;

    [ObservableProperty]
    public string nombre;

    private readonly AreaBL _areaBL;

    [ObservableProperty]
    public string mensaje;
    public AreaViewModel(AreaBL areaBL)
    {
        _areaBL = areaBL;
        nombre = string.Empty;
        mensaje = string.Empty;
    }



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
            AreaDto area = await _areaBL.GetPorIdAsync(areaId);
            if (area != null)
            {
                nombre = area!.Nombre ?? string.Empty;
            }
        }
        catch (JWorkExecectioncs ex)
        {
            await GlobalAlertas.Error(ex.Message);
        }
        catch (Exception)
        {
        }

    }


    [RelayCommand]
    private async Task Crear()
    {
        try
        {
            AreaDto area = new()
            {
                Nombre = Nombre
            };
            await _areaBL.Crear(area);
            await Application.Current?.MainPage?.DisplayAlert("Éxito", "Creado", "Ok",flowDirection:FlowDirection.LeftToRight);

        }
        catch (JWorkExecectioncs ex)
        {
            await Application.Current?.MainPage?.DisplayAlert("Error", ex.Message, "Ok", flowDirection: FlowDirection.LeftToRight);

        }
        catch (Exception ex)
        {
            await Application.Current?.MainPage?.DisplayAlert("Error", ex.Message, "Ok", flowDirection: FlowDirection.LeftToRight);
        }
    }
}

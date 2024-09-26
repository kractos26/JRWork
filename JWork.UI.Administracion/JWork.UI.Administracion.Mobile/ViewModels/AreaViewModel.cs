using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Mobile.Views.Buscar;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Mobile.ViewModels;

public partial class AreaViewModel : ViewModelGlobal
{
    private readonly AreaBL _areaBL;
    public AreaViewModel(AreaBL areaBL)
    {
        _areaBL = areaBL;
        if (_areaBL == null)
        {
            throw new InvalidOperationException("El servicio AreaBL no está inicializado.");
        }
        IsNotificationVisible = false;
    }
    [ObservableProperty]
    public int areaId;

    [ObservableProperty]
    public string nombre = string.Empty;
    [ObservableProperty]
    public string mensaje = string.Empty;


    [RelayCommand]
    private async Task Guardar()
    {
        try
        {
            AreaDto area = new()
            {
                AreaId = AreaId,
                Nombre = Nombre
            };

            if (area.AreaId > 0)
            {
                area = await _areaBL.Modificar(area);
            }
            else
            {
                area = await _areaBL.Crear(area);
            }

            if (area.AreaId > 0)
            {
                await MostrarAlerta("Operación exitosa", false);
            }

        }
        catch (JWorkException ex)
        {
            Console.WriteLine(ex.Message);
            await MostrarAlerta("El area fue creada correctamente", true);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            await MostrarAlerta("El area fue creada correctamente", true);
        }
    }


    public async Task MostrarAlerta(string mensaje, bool esError)
    {
        // Establece el mensaje y el color
        Mensaje = mensaje;
        NotificationColor = esError ? Colors.Red : Colors.Green;
        IsNotificationVisible = true;

        // Muestra el mensaje durante unos segundos
        await Task.Delay(4000);

        // Oculta el mensaje
        IsNotificationVisible = false;
    }


  


}

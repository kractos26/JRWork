using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Mobile.Views.Buscar;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Mobile.ViewModels;

public partial class AreaViewModel(AreaBL areaBL) : ViewModelGlobal, IQueryAttributable
{
    [ObservableProperty]
    public int areaId;

    [ObservableProperty]
    public string nombre = string.Empty;
    [ObservableProperty]
    public string mensaje = string.Empty;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!(!query.ContainsKey("id") || !int.TryParse(query["id"]?.ToString(), out int id)))
        {
            AreaId = id;
        }
    }

    public async Task InicializarAsync()
    {
        if (AreaId <= 0)
        {
            return;
        }

        try
        {
            AreaDto area = await areaBL.GetPorIdAsync(AreaId);
            if (area != null)
            {
                Nombre = area!.Nombre ?? string.Empty;
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


    [RelayCommand]
    private async Task Crear()
    {
        try
        {
            AreaDto area = new()
            {
                Nombre = Nombre
            };
            AreaDto respu = await areaBL.Crear(area);
            if (respu.AreaId > 0)
            {
                await MostrarAlerta("El area creada correctamente", false);
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
        // Cambia los colores según si es un error o éxito
        var backgroundColor = esError ? Colors.Red : Colors.Green;
        var textColor = Colors.White;
        var duration = TimeSpan.FromSeconds(4);

        var snackbarOptions = new SnackbarOptions
        {
            BackgroundColor = backgroundColor,
            TextColor = textColor,
            ActionButtonTextColor = Colors.White,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(14)

        };


        var snackbar = Snackbar.Make(mensaje, action: async () =>
        {
            await Shell.Current.GoToAsync(nameof(AreasPage));
        }, "Cerrar", duration, snackbarOptions);

        await snackbar.Show();
    }
}

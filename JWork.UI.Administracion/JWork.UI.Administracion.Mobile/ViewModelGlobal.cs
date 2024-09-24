using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
namespace JWork.UI.Administracion.Mobile;

public abstract class ViewModelGlobal : ObservableObject
{

    private async Task MostrarAlertaToast(string mensaje)
    {
        ToastDuration duration = ToastDuration.Short;

        IToast toast = Toast.Make(mensaje, duration, 14);
        await toast.Show();
    }

}

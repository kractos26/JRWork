using CommunityToolkit.Maui.Views;
using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class AreaPopup : Popup
{


    public AreaPopup(AreaViewModel? viewModel)
    {
        try
        {
            InitializeComponent();
            BindingContext = viewModel ?? throw new ArgumentNullException(nameof(viewModel), "El ViewModel no puede ser null.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al inicializar el Popup: {ex.Message}\nStackTrace: {ex.StackTrace}");
            _ = Shell.Current.DisplayAlert("Error", "No se pudo inicializar el Popup correctamente", "OK");

        }
    }



}
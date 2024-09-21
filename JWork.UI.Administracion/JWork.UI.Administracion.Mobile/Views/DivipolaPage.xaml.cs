using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class DivipolaPage : ContentPage
{
    private readonly DivipolaViewModel _model;
    public DivipolaPage(DivipolaViewModel model)
    {
        _model = model;
        InitializeComponent();
        BindingContext = model;
    }

    protected override async void OnAppearing()
    {
        await _model.Inicializar();
    }
}
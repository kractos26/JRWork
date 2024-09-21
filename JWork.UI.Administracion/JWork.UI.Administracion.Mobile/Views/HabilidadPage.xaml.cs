using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class HabilidadPage : ContentPage
{
    private readonly HabilidadViewModel _model;
    public HabilidadPage(HabilidadViewModel model)
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
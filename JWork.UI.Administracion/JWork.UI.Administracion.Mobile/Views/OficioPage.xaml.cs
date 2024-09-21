using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class OficioPage : ContentPage
{
    private readonly OficioViewModel _model;
    public OficioPage(OficioViewModel model)
    {
        _model = model;
        InitializeComponent();
        BindingContext = model;
    }

    protected override async void OnAppearing()
    {
        await _model.InicializarAsync();
    }
}
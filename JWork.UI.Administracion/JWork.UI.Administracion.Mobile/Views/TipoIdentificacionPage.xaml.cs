using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class TipoIdentificacionPage : ContentPage
{
    private readonly TipoIdentificacionViewModel _model;
    public TipoIdentificacionPage(TipoIdentificacionViewModel model)
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
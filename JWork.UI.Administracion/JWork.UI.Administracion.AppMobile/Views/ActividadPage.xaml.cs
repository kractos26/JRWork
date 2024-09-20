using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class ActividadPage : ContentPage
{
    private readonly ActividadViewModel _models;

    public ActividadPage(ActividadViewModel models)
    {
        InitializeComponent();
        _models = models;
        BindingContext = _models;
    }

    protected override async void OnAppearing()
    {
        
        await _models.InicializarAsync();
    }
}

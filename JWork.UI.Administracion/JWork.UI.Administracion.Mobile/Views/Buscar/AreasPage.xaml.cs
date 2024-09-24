using JWork.UI.Administracion.Mobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.Mobile.Views.Buscar;

public partial class AreasPage : ContentPage
{
    private readonly AreaGridViewModel _model;
    public AreasPage(AreaGridViewModel model)
    {
        InitializeComponent();
        _model = model;
        BindingContext = _model;


    }

    protected override async void OnAppearing()
    {

        await _model.ObtenerData();
    }

    private async void OnBuscar(object sender, TextChangedEventArgs e)
    {
        await _model.Buscar();
    }
}
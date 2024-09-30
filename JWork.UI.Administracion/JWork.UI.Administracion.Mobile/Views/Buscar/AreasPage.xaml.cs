using JWork.UI.Administracion.Mobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.Mobile.Views.Buscar;

public partial class AreasPage : ContentPage
{
    private readonly AreaGridViewModel _model;
    private Timer _searchTimer;
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

    private void OnBuscar(object sender, TextChangedEventArgs e)
    {
        _ = (_searchTimer?.Change(Timeout.Infinite, 0));

        _searchTimer = new Timer(async _ =>
        {
            await _model.Buscar();
            _searchTimer?.Dispose();
        }, null, 500, Timeout.Infinite);
    }
}
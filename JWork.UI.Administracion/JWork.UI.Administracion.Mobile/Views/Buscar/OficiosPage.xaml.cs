using JWork.UI.Administracion.Mobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.Mobile.Views.Buscar;

public partial class OficiosPage : ContentPage
{
    private readonly OficioGridViewModel _modelo;
    private Timer? _searchTimer;

    public OficiosPage(OficioGridViewModel model)
    {
        InitializeComponent();
        _modelo = model;
        BindingContext = _modelo;
    }

    protected override async void OnAppearing()
    {
        await _modelo.ObtenerData();
    }

    private void OnBuscar(object sender, TextChangedEventArgs e)
    {
        _ = (_searchTimer?.Change(Timeout.Infinite, 0));

        _searchTimer = new Timer(async _ =>
        {
            await _modelo.Buscar();
            _searchTimer?.Dispose();
        }, null, 500, Timeout.Infinite);
    }
}
using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class UnidadMedidasPage : ContentPage
{
    private readonly UnidadMedidaGridViewModel _model;

    public UnidadMedidasPage(UnidadMedidaGridViewModel model)
	{
        _model = model;
        BindingContext = _model;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        OnAppearing();
        await _model.ObtenerData();
    }
}
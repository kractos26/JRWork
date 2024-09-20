using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class OficiosPage : ContentPage
{
	private readonly OficioGridViewModel _model;
	public OficiosPage(OficioGridViewModel model)
	{
		_model = model;
		BindingContext = _model;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        
        await _model.ObtenerData();
    }
}
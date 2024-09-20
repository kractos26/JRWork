using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class UnidadMedidaPage : ContentPage
{
	private readonly UnidadMedidaViewModel _model;
	public UnidadMedidaPage(UnidadMedidaViewModel model)
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
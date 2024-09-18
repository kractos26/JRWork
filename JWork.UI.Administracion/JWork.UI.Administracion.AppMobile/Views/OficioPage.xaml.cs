using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class OficioPage : ContentPage
{
	private readonly OficioViewModel _model;
	public OficioPage(OficioViewModel model )
	{
		_model = model;
		InitializeComponent();
		BindingContext = model;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await	_model.InicializarAsync();
    }
}
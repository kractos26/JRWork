using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

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
        base.OnAppearing();
		await _model.InicializarAsync();
    }
}
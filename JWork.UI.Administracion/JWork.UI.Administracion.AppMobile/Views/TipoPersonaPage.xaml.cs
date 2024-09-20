using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class TipoPersonaPage : ContentPage
{
	private readonly TipoPersonaViewModel _model;
	public TipoPersonaPage(TipoPersonaViewModel model)
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
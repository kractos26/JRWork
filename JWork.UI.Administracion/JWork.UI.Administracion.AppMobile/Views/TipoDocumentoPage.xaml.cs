using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class TipoDocumentoPage : ContentPage
{ 
	private readonly TipoDocumentoViewModel _model;
	public TipoDocumentoPage(TipoDocumentoViewModel model)
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
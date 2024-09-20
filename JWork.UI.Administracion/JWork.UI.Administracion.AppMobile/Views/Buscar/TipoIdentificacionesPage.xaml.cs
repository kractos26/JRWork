using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class TipoIdentificacionesPage : ContentPage
{
	private readonly TipoIdentificacionGridViewModel _model;
    public TipoIdentificacionesPage(TipoIdentificacionGridViewModel model)
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
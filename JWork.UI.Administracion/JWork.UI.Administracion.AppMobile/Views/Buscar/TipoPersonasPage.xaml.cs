using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class TipoPersonasPage : ContentPage
{
	private readonly TipoPersonaGridViewModel _model;
    public TipoPersonasPage(TipoPersonaGridViewModel model)
	{
        _model = model;
		BindingContext = model;
		InitializeComponent();
		
	}


    protected override async void OnAppearing()
    {
        OnAppearing();
        await _model.ObtenerData();
    }

}
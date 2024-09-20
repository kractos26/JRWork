using JWork.UI.Administracion.AppMobile.ViewModels;
using JWork.UI.Administracion.Business;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class HabilidadPage : ContentPage
{
	private readonly HabilidadViewModel _model;
	public HabilidadPage(HabilidadViewModel model)
	{
		_model = model;
		InitializeComponent();
		BindingContext = model;
	}

    protected override async void OnAppearing()
    {
		await _model.Inicializar();
    }
}
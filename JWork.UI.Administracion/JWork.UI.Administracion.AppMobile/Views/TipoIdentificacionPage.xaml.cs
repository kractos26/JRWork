using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class TipoIdentificacionPage : ContentPage
{
	public TipoIdentificacionPage(TipoIdentificacionViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
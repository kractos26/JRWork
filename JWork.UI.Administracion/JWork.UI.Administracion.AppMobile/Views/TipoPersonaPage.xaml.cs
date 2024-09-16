using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class TipoPersonaPage : ContentPage
{
	public TipoPersonaPage(TipoPersonaViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
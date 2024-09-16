using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class OficioPage : ContentPage
{
	public OficioPage(OficioViewModel model )
	{
		InitializeComponent();
		BindingContext = model;
	}
}
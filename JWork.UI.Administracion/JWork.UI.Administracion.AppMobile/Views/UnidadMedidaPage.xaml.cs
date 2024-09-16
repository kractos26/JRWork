using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class UnidadMedidaPage : ContentPage
{
	public UnidadMedidaPage(UnidadMedidaViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
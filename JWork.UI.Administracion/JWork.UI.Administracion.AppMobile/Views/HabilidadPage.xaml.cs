using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class HabilidadPage : ContentPage
{
	public HabilidadPage(HabilidadViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
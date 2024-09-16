using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class DivipolaPage : ContentPage
{
	public DivipolaPage(DivipolaViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
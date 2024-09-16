using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class ActividadPage : ContentPage
{
	public ActividadPage(ActividadVIewModels models)
	{
		InitializeComponent();
		BindingContext = models;
	}
}
using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class ConceptoCalificacionPage : ContentPage
{
	public ConceptoCalificacionPage(ConceptoCalificacionViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
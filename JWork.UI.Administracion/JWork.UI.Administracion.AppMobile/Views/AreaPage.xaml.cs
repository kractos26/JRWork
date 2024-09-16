using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class AreaPage : ContentPage
{
	public AreaPage(AreaViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
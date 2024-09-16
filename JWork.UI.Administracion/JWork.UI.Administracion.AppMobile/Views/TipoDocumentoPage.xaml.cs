using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class TipoDocumentoPage : ContentPage
{
	public TipoDocumentoPage(TipoDocumentoViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}
using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class TipoDocumentosPage : ContentPage
{
	private readonly TipoDocumentoGridViewModel _model;
    public TipoDocumentosPage(TipoDocumentoGridViewModel model)
	{
		_model = model;
		BindingContext = _model;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        OnAppearing();
        await _model.ObtenerData();
    }
}
using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class ConceptoCalificacionesPage : ContentPage
{
	private readonly ConceptoCalificacionGridViewModel _model;
	public ConceptoCalificacionesPage(ConceptoCalificacionGridViewModel model)
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
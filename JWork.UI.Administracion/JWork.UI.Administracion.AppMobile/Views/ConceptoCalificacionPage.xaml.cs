using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class ConceptoCalificacionPage : ContentPage
{
	private readonly ConceptoCalificacionViewModel _viewModel;
	public ConceptoCalificacionPage(ConceptoCalificacionViewModel model)
	{
		_viewModel = model;
		InitializeComponent();
		BindingContext = _viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await _viewModel.Inicializar();
    }
}
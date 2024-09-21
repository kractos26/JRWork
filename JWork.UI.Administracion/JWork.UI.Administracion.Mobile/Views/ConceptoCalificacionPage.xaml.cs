using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

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
        await _viewModel.Inicializar();
    }
}
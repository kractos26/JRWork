using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class HabilidadesPage : ContentPage
{
    private readonly HabilidadGridViewModel _model;
    public HabilidadesPage(HabilidadGridViewModel model)
    {
        _model = model;
        InitializeComponent();
        BindingContext = model;
    }

    protected override async void OnAppearing()
    {
        OnAppearing();
        await _model.ObtenerData();
    }
}
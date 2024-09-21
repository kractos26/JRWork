using JWork.UI.Administracion.Mobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.Mobile.Views.Buscar;

public partial class AreasPage : ContentPage
{
    private readonly AreaGridViewModel _model;
    public AreasPage(AreaGridViewModel model)
	{
        _model = model;
        BindingContext = _model;

        InitializeComponent();
	}

    protected override async void OnAppearing()
    {

        await _model.ObtenerData();
    }
}
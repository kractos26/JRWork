using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class ActividadesPage : ContentPage
{

    private readonly ActividadGridViewModel _model;
    public ActividadesPage(ActividadGridViewModel model)
    {
        _model = model;  
        InitializeComponent();
        BindingContext = _model;
    }

    protected override async void OnAppearing()
    {
        await _model.ObtenerData();
    }

    private void Nuevo_Clicked(object sender, EventArgs e)
    {

    }
}

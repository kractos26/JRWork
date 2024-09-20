using JWork.UI.Administracion.AppMobile.ViewModels.Buscar;

namespace JWork.UI.Administracion.AppMobile.Views.Buscar;

public partial class DivipolasPage : ContentPage
{
   private readonly DivipolaGridViewModel _model;
	public DivipolasPage(DivipolaGridViewModel model)
	{
        _model = model;
        BindingContext = model;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
       
        await _model.ObtenerData();
    }
}
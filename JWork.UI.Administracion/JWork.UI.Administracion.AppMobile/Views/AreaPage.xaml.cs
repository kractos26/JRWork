using JWork.UI.Administracion.AppMobile.ViewModels;

namespace JWork.UI.Administracion.AppMobile.Views;

public partial class AreaPage : ContentPage
{
	private readonly AreaViewModel _model;
	public AreaPage(AreaViewModel model)
	{
		_model = model;
		InitializeComponent();
		BindingContext = model;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await _model.InicializarAsync();
    }
}
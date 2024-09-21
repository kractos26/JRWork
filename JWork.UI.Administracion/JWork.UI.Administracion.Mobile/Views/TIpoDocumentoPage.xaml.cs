using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class TipoDocumentoPage : ContentPage
{
    private readonly TipoDocumentoViewModel _model;
    public TipoDocumentoPage(TipoDocumentoViewModel model)
    {
        _model = model;
        InitializeComponent();
        BindingContext = model;
    }

    protected override async void OnAppearing()
    {
        await _model.InicializarAsync();
    }
}
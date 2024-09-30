using CommunityToolkit.Maui.Views;
using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class OficioPopup : Popup
{
    private readonly OficioViewModel _model;
    public OficioPopup(OficioViewModel model)
    {
        _model = model;
        InitializeComponent();

        BindingContext = model;
    }


}
using CommunityToolkit.Maui.Views;
using JWork.UI.Administracion.Mobile.ViewModels;

namespace JWork.UI.Administracion.Mobile.Views;

public partial class AreaPopup : Popup
{
    private readonly AreaViewModel _viewModel;

    public AreaPopup(AreaViewModel viewModel)
    {
       InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}
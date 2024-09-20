using JWork.UI.Administracion.AppMobile.ViewModels;
using CommunityToolkit.Maui.Views;

namespace JWork.UI.Administracion.AppMobile.Views
{
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
}

/* [grial-metadata] id: Grial#NewsTopicsPage.cs version: 1.0.1 */
namespace JWork.UI.Administracion.Mobile.Views.Buscar;

public partial class NewsTopicsPage : ContentPage
{
    public NewsTopicsPage()
    {
        InitializeComponent();

        BindingContext = new NewsTopicsViewModel();
    }
}

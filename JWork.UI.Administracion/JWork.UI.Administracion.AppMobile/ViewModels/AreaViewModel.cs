using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels;

public partial class AreaViewModel : ViewModelGlobal
{
    private readonly AreaDto _area;

    public AreaViewModel()
    {
        _area = new AreaDto();
    }

    [ObservableProperty]
    public int areaId;

    [ObservableProperty]
    public string nombre;
    

}

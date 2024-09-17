using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels;

public partial class AreaViewModel : ViewModelGlobal
{
   

    public AreaViewModel()
    {
       nombre = string.Empty;
    }

    [ObservableProperty]
    public int areaId;

    [ObservableProperty]
    public string nombre;
    

}

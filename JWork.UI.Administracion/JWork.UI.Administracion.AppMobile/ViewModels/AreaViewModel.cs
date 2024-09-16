using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels;

public class AreaViewModel : BindingUtilObject
{
    private readonly AreaDto _area;

    public AreaViewModel()
    {
        _area = new AreaDto();
    }

    public  int AreaId
    {
        get { return _area.AreaId; }
        set
        {
            if (_area.AreaId != value)
            {
                _area.AreaId = value;
                RaisePropertyChanged(nameof(AreaId));
            }
        }
    }

    public  string Nombre
    {
        get { return _area.Nombre; }
        set
        {
            if (_area.Nombre != value)
            {
                _area.Nombre = value;
                RaisePropertyChanged(nameof(Nombre));
            }
        }
    }

}

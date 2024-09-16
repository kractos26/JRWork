using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JWork.UI.Administracion.AppMobile;

public class BindingUtilObject : INotifyPropertyChanged
{
    public void RaisePropertyChanged(
                [CallerMemberName] string? propertyName = null
        )
    { 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
}

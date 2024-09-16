using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels;

public partial class ActividadVIewModels : ViewModelGlobal
{

    private readonly ActividadDto _area;
    public ActividadVIewModels()
    {
        _area = new();
        oficios = [];//Data llega del business
        oficioSeleccionado = new();//Data llega del business
        PropertyChanged += BindingUtil_PropertyChanged;
    }

    private void BindingUtil_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(oficioSeleccionado))
        {
            _area.OficioId = OficioSeleccionado.OficioId;

        }
    }

    [ObservableProperty]
    public int actividadId;
    

    [ObservableProperty]
    public string? nombre;
  

    [ObservableProperty]
    public int oficioId;



    [ObservableProperty]
    public ObservableCollection<OficioDto>? oficios;



    [ObservableProperty]
    public OficioDto oficioSeleccionado;

}

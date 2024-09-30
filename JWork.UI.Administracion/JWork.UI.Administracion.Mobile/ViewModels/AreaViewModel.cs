using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.Mobile.ViewModels;

public partial class AreaViewModel : ViewModelGlobal
{
    private readonly AreaBL _areaBL;
    public AreaViewModel(AreaBL areaBL)
    {
        _areaBL = areaBL;
        if (_areaBL == null)
        {
            throw new InvalidOperationException("El servicio AreaBL no está inicializado.");
        }

    }
    [ObservableProperty]
    public int areaId;

    [ObservableProperty]
    public string nombre = string.Empty;
    [ObservableProperty]
    public string mensaje = string.Empty;


    [RelayCommand]
    private async Task Guardar()
    {
        try
        {
            AreaDto area = new()
            {
                AreaId = AreaId,
                Nombre = Nombre
            };

            area = area.AreaId > 0 ? await _areaBL.Modificar(area) : await _areaBL.Crear(area);



        }
        catch (JWorkException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }








}

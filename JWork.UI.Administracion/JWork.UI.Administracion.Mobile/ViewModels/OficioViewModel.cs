using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class OficioViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public int oficioId;

        [ObservableProperty]
        public string oficioName;

        [ObservableProperty]
        public int areaId;

        [ObservableProperty]
        private ObservableCollection<AreaDto> areas;


        [ObservableProperty]
        private AreaDto areaSeleccionada;

        private readonly OficioBL _oficioBL;
        private readonly AreaBL _areaBL;
        public OficioViewModel(OficioBL oficioBL, AreaBL areaBL)
        {
            _oficioBL = oficioBL;
            _areaBL = areaBL;
            oficioName = string.Empty;
            areas = [];
            areaSeleccionada = new();
        }


        public async Task InicializarAsync()
        {

            try
            {

                List<AreaDto> arealst = await _areaBL.Buscar(new()
                {
                    Entidad = new(),
                    TotalRegistros = 20,
                    NumeroPagina = 1,
                });
                Areas = new ObservableCollection<AreaDto>(arealst ?? []);
                if (AreaId > 0)
                {
                    AreaDto? areaSeleccionada = Areas.FirstOrDefault(a => a.AreaId == AreaId);
                    if (areaSeleccionada != null)
                    {
                        AreaSeleccionada = areaSeleccionada;
                    }
                }

            }
            catch (Exception ex)
            {

                await MostrarError($"Ocurrió un error al cargar los datos: {ex.Message}");

            }
        }

        [RelayCommand]
        private async Task Guardar()
        {
            try
            {
                OficioDto oficio = new()
                {
                    AreaId = AreaSeleccionada.AreaId,
                    Nombre = OficioName,
                    OficioId = OficioId,

                };

                oficio = oficio.OficioId > 0 ? await _oficioBL.Modificar(oficio) : await _oficioBL.Crear(oficio);
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


        private Task MostrarError(string mensaje)
        {
            _ = Shell.Current.DisplayAlert("Error", mensaje, "Cancelar");
            return Task.CompletedTask;
        }


    }
}

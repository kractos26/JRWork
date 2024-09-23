using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class OficioViewModel : ViewModelGlobal, IQueryAttributable
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
            if (AreaId <= 0)
            {
                return;
            }

            try
            {
                OficioDto response = await _oficioBL.GetPorIdAsync(OficioId);

                // Validar la respuesta
                if (response != null)
                {
                    OficioName = response.Nombre;
                    AreaId = response.AreaId;
                    AreaSeleccionada = response.Area ?? new AreaDto();
                    List<AreaDto> arealst = await _areaBL.Buscar(new () { 
                        Entidad = new(),
                    TotalRegistros = 20,
                    NumeroPagina = 1,
                    });
                    Areas = new ObservableCollection<AreaDto>(arealst ?? []);
                }
                
            }
            catch (Exception ex)
            {

                await MostrarError($"Ocurrió un error al cargar los datos: {ex.Message}");

            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
            {
                OficioId = id;
            }
        }

        private Task MostrarError(string mensaje)
        {
            Shell.Current.DisplayAlert("Error", mensaje, "Cancelar");
            return Task.CompletedTask;
        }
    }
}

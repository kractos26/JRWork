using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;
using static JWork.UI.Administracion.Common.Constantes;

namespace JWork.UI.Administracion.AppMobile.ViewModels
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
        }


        public async Task InicializarAsync()
        {
            if (areaId <= 0)
            {
                return;
            }

            try
            {
                var response = await _oficioBL.GetPorIdAsync(oficioId);

                // Validar la respuesta
                if (response.Status == System.Net.HttpStatusCode.OK && response.Entidad != null)
                {
                    oficioName = response.Entidad.Nombre;
                    areaId = response.Entidad.AreaId;
                    areaSeleccionada = response.Entidad.Area ?? new AreaDto();
                    Common.Response<List<AreaDto>> arealst = await _areaBL.Buscar(new AreaDto() { });
                    areas = new ObservableCollection<AreaDto>(arealst.Entidad ?? []);
                }
                else
                {
                    await MostrarError(response.Mensaje ?? string.Empty);
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
                oficioId = id;
            }
        }

        private Task MostrarError(string mensaje)
        {
            return Task.CompletedTask;
        }
    }
}

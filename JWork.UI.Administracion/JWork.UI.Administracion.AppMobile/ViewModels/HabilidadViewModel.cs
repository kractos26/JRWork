using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Models.Request;
using System.Collections.ObjectModel;
using static JWork.UI.Administracion.Common.Constantes;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class HabilidadViewModel : ViewModelGlobal,IQueryAttributable
    {
        [ObservableProperty]
        public int habilidadId;


        [ObservableProperty]
        public string nombre;


        [ObservableProperty]
        public int actividadId;

        [ObservableProperty]
        private ObservableCollection<ActividadDto> actividades;


        [ObservableProperty]
        private ActividadDto actividadSeleccionada;
        private readonly HabilidadBL _habilidadBL;
        private readonly ActividadBL _actividadBL;
        public HabilidadViewModel(HabilidadBL habilidadBL,ActividadBL actividadBL)
        {
            _habilidadBL = habilidadBL;
            _actividadBL = actividadBL;
            nombre = string.Empty;
            actividades = [];
            actividadSeleccionada = new();
        }

        public async Task Inicializar()
        {
            if (habilidadId <= 0)
            {
                return;
            }

            try
            {
                var response = await _habilidadBL.GetPorIdAsync(habilidadId);

                // Validar la respuesta
                if ( response != null)
                {
                    Nombre = response.Nombre;
                    actividadId = response.ActividadId;
                    actividadSeleccionada = response.Actividad ?? new ActividadDto();
                    List<ActividadDto> actividalst = await _actividadBL.Buscar(new () { 
                        NumeroPagina = 1,
                        TotalRegistros = 20,
                    });
                    actividades = new ObservableCollection<ActividadDto>(actividalst ?? []);
                }
               
            }
            catch (Exception ex)
            {
                await MostrarError($"Ocurrió un error al cargar los datos: {ex.Message}");
            }
        }

        private Task MostrarError(string mensaje)
        {
            return Task.CompletedTask;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
            {
                habilidadId = id;
            }
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Models.Request;
using System.Collections.ObjectModel;
using static JWork.UI.Administracion.Common.Constantes;

namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class HabilidadViewModel(HabilidadBL habilidadBL, ActividadBL actividadBL) : ViewModelGlobal,IQueryAttributable
    {
        [ObservableProperty]
        public int habilidadId;


        [ObservableProperty]
        public string nombre = string.Empty;


        [ObservableProperty]
        public int actividadId;

        [ObservableProperty]
        private ObservableCollection<ActividadDto> actividades = [];


        [ObservableProperty]
        private ActividadDto actividadSeleccionada = new();
        private readonly HabilidadBL _habilidadBL = habilidadBL;
        private readonly ActividadBL _actividadBL = actividadBL;

        public async Task Inicializar()
        {
            if (HabilidadId <= 0)
            {
                return;
            }

            try
            {
                var response = await _habilidadBL.GetPorIdAsync(HabilidadId);

                // Validar la respuesta
                if ( response != null)
                {
                    Nombre = response.Nombre;
                    ActividadId = response.ActividadId;
                    ActividadSeleccionada = response.Actividad ?? new ActividadDto();
                    List<ActividadDto> actividalst = await _actividadBL.Buscar(new () { 
                        Entidad = new(),
                        NumeroPagina = 1,
                        TotalRegistros = 20,
                    });
                    Actividades = new ObservableCollection<ActividadDto>(actividalst ?? []);
                }
               
            }
            catch (Exception ex)
            {
                await MostrarError($"Ocurrió un error al cargar los datos: {ex.Message}");
            }
        }

        private Task MostrarError(string mensaje)
        {
            Shell.Current.DisplayAlert("Error", mensaje, "Cancelar");
            return Task.CompletedTask;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
            {
                HabilidadId = id;
            }
        }
    }
}

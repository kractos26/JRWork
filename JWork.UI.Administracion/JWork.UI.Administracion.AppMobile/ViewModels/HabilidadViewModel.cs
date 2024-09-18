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
                if (response.Status == System.Net.HttpStatusCode.OK && response.Entidad != null)
                {
                    Nombre = response.Entidad.Nombre;
                    actividadId = response.Entidad.ActividadId;
                    actividadSeleccionada = response.Entidad.Actividad ?? new ActividadDto();
                    Common.Response<List<ActividadDto>> actividalst = await _actividadBL.Buscar(new ActividadRequest() { });
                    actividades = new ObservableCollection<ActividadDto>(actividalst.Entidad ?? []);
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

using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using static JWork.UI.Administracion.Common.Constantes;

namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class TipoPersonaViewModel : ViewModelGlobal,IQueryAttributable
    {
        [ObservableProperty]
        public int tipoPersonaId;

        [ObservableProperty]
        public string nombre;

        private readonly TipoPersonaBL _tipoPersonaBL;
        public TipoPersonaViewModel(TipoPersonaBL tipoPersonaBL)
        {
            _tipoPersonaBL = tipoPersonaBL;
            nombre = string.Empty;
        }

        public async Task InicializarAsync()
        {
            if (tipoPersonaId <= 0)
            {
                return;
            }

            try
            {
                var response = await _tipoPersonaBL.GetPorIdAsync(tipoPersonaId);

                // Validar la respuesta
                if (response != null)
                {
                    nombre = response.Nombre;
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
                tipoPersonaId = id;
            }
        }

        private Task MostrarError(string mensaje)
        {
            return Task.CompletedTask;
        }

    }
}

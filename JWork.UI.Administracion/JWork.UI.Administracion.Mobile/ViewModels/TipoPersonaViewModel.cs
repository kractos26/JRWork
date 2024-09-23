using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using static JWork.UI.Administracion.Common.Constantes;

namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class TipoPersonaViewModel(TipoPersonaBL tipoPersonaBL) : ViewModelGlobal,IQueryAttributable
    {
        [ObservableProperty]
        public int tipoPersonaId;

        [ObservableProperty]
        public string nombre = string.Empty;

        public async Task InicializarAsync()
        {
            if (TipoPersonaId <= 0)
            {
                return;
            }

            try
            {
                var response = await tipoPersonaBL.GetPorIdAsync(TipoPersonaId);

                // Validar la respuesta
                if (response != null)
                {
                    Nombre = response.Nombre;
                }
              
            }
            catch (Exception ex)
            {

                await MostrarError($"Ocurrió un error al cargar los datos: {ex.Message}");

            }
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (!(!query.ContainsKey("id") || !int.TryParse(query["id"]?.ToString(), out var id)))
            {
                TipoPersonaId = id;
            }
        }

        private static Task MostrarError(string mensaje)
        {
            Shell.Current.DisplayAlert("", mensaje, "ok");
            return Task.CompletedTask;
        }
    }
}

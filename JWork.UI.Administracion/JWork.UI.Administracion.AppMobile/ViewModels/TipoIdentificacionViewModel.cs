using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class TipoIdentificacionViewModel : ViewModelGlobal,IQueryAttributable
    {
        [ObservableProperty]
        public int tipoIdentificacionId;

        [ObservableProperty]
        public string sigla;

        [ObservableProperty]
        public string nombre;

        private readonly TipoIdentificacionBL _tipoIdentificacionBL;
        public TipoIdentificacionViewModel(TipoIdentificacionBL tipoIdentificacionBL)
        {
            _tipoIdentificacionBL = tipoIdentificacionBL;
        }

 

        public async Task InicializarAsync()
        {
            if (tipoIdentificacionId <= 0)
            {
                return;
            }

            try
            {
                var response = await _tipoIdentificacionBL.GetPorIdAsync(tipoIdentificacionId);

                // Validar la respuesta
                if (response.Status == System.Net.HttpStatusCode.OK && response.Entidad != null)
                {
                    nombre = response.Entidad.Nombre;
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
                tipoIdentificacionId = id;
            }
        }

        private Task MostrarError(string mensaje)
        {
            return Task.CompletedTask;
        }

    }
}

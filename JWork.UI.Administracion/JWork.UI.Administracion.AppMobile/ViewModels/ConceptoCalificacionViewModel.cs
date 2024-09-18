using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class ConceptoCalificacionViewModel : ViewModelGlobal, IQueryAttributable
    {
        private readonly ConceptoCalificacionBL _conceptoCalificacionBL;

        public ConceptoCalificacionViewModel(ConceptoCalificacionBL conceptoCalificacionBL)
        {
            _conceptoCalificacionBL = conceptoCalificacionBL;
        }

        [ObservableProperty]
        private int conceptoCalificacionId;

        [ObservableProperty]
        private string? nombre;

        [ObservableProperty]
        private string? descripcion;

        // Método para recibir atributos de consulta (ejemplo: desde una URL)
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
            {
                ConceptoCalificacionId = id;
            }
        }

        public async Task Inicializar()
        {
            if (ConceptoCalificacionId <= 0)
            {
                return;
            }

            try
            {
                var response = await _conceptoCalificacionBL.GetPorIdAsync(ConceptoCalificacionId);

                // Validar la respuesta
                if (response.Status == System.Net.HttpStatusCode.OK && response.Entidad != null)
                {
                    Nombre = response.Entidad.Nombre;
                    Descripcion = response.Entidad.Descripcion;
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
    }
}

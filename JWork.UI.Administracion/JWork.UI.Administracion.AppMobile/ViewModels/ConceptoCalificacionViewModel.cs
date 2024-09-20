using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;

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

                if (response != null)
                {
                    Nombre = response.Nombre;
                    Descripcion = response.Descripcion;
                }
                
            }
            catch(JWorkExecectioncs ex) 
            {
                await MostrarError(ex.Message);
            }
            catch (Exception ex)
            {
            }
        }

        private Task MostrarError(string mensaje)
        {
            ////var notification = new NotificationRequest
            ////{
            ////    NotificationId = 1001,
            ////    Title = "Acción Completada",
            ////    Description = "La acción se ha completado exitosamente.",
            ////    ReturningData = "AcciónCompletada", // Datos adicionales si es necesario
            ////    NotifyTime = DateTime.Now // Notificación inmediata
            ////};

            ////NotificationCenter.Current.Show(notification);
            ///
            return null;
        }
    }
}

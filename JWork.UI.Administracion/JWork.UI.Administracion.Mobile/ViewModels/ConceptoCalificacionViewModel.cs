using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;

namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class ConceptoCalificacionViewModel : ViewModelGlobal, IQueryAttributable
    {
        private readonly ConceptoCalificacionBL _conceptoCalificacionBL;

        public ConceptoCalificacionViewModel(ConceptoCalificacionBL conceptoCalificacionBL)
        {
            _conceptoCalificacionBL = conceptoCalificacionBL;
        }

        [ObservableProperty]
        private  int conceptoCalificacionId;

        [ObservableProperty]
        private string? nombre;

        [ObservableProperty]
        private string? descripcion;

        // Método para recibir atributos de consulta (ejemplo: desde una URL)
        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("id") && int.TryParse(query["id"]?.ToString(), out var id))
            {
                conceptoCalificacionId = id;
            }
        }

        public async Task Inicializar()
        {
            if (conceptoCalificacionId <= 0)
            {
                return;
            }

            try
            {
                var response = await _conceptoCalificacionBL.GetPorIdAsync(conceptoCalificacionId);

                if (response != null)
                {
                    nombre = response.Nombre;
                    descripcion = response.Descripcion;
                }
                
            }
            catch(JWorkExecectioncs ex) 
            {
                await GlobalAlertas.Error(ex.Message);
            }
            catch (Exception)
            {
            }
        }

       
    }
}

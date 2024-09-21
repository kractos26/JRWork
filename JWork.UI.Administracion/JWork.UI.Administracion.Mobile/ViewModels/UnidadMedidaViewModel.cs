using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;


namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class UnidadMedidaViewModel : ViewModelGlobal, IQueryAttributable
    {
        [ObservableProperty]
        public int unidadMedidaId;


        [ObservableProperty]
        public string? nombre;

        private readonly UnidadMedidaBL _unidadMedidaBL;
        
        public UnidadMedidaViewModel(UnidadMedidaBL unidadMedidaBL)
        {
            _unidadMedidaBL = unidadMedidaBL;
        }

        public async Task InicializarAsync()
        {
            if (unidadMedidaId <= 0)
            {
                return;
            }

            try
            {
                var response = await _unidadMedidaBL.GetPorIdAsync(unidadMedidaId);

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
                unidadMedidaId = id;
            }
        }

        private Task MostrarError(string mensaje)
        {
            return Task.CompletedTask;
        }
    }
}

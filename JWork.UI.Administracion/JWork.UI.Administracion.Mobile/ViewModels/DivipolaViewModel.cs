using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;

namespace JWork.UI.Administracion.Mobile.ViewModels
{
    public partial class DivipolaViewModel : ViewModelGlobal,IQueryAttributable
    {
        [ObservableProperty]
        public int divipolaId;


        [ObservableProperty]

        public decimal codigo;


        [ObservableProperty]
        public string nombre;


        [ObservableProperty]
        public decimal? codigoPadre;

        private readonly DivipolaBL _divipolaBL;
        public DivipolaViewModel(DivipolaBL divipolaBL)
        {
            _divipolaBL = divipolaBL;
            nombre = string.Empty;
        }

        public async Task Inicializar()
        {
            if (DivipolaId <= 0)
            {
                return;
            }

            try
            {
                var response = await _divipolaBL.GetPorIdAsync(DivipolaId);

                // Validar la respuesta
                if (response != null)
                {
                    Nombre = response.Nombre;
                    Codigo = response.Codigo;
                    CodigoPadre = response.CodigoPadre;
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
                DivipolaId = id;
            }
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using static JWork.UI.Administracion.Common.Constantes;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels
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
        }

        public async Task Inicializar()
        {
            if (divipolaId <= 0)
            {
                return;
            }

            try
            {
                var response = await _divipolaBL.GetPorIdAsync(divipolaId);

                // Validar la respuesta
                if (response.Status == System.Net.HttpStatusCode.OK && response.Entidad != null)
                {
                    Nombre = response.Entidad.Nombre;
                    codigo = response.Entidad.Codigo;
                    codigoPadre = response.Entidad.CodigoPadre;
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
                divipolaId = id;
            }
        }
    }
}

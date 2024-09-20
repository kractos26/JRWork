using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Models;
using JWork.UI.Administracion.Models.Request;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class ActividadGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        string? textoBusqueda;

        [ObservableProperty]
        public ObservableCollection<ActividadDto> actividades;

        [ObservableProperty]
        public ActividadDto actividadselecionada;

        [ObservableProperty]
        private string? mensaje;

        private readonly ActividadBL _actividadBL;
        private readonly INavigationService _navigationService;
        public  ActividadGridViewModel(ActividadBL actividadBL,INavigationService navigationService)
        {
            _actividadBL = actividadBL;
            actividadselecionada = new ActividadDto();
            actividades = [];
            _navigationService = navigationService;
            PropertyChanged += ActividadGridViewModel_PropertyChanged;
        }

        private async void ActividadGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(actividadselecionada))
            {
                string uri = $"{nameof(ActividadPage)}?id={actividadselecionada.ActividadId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<ActividadDto> resp = await _actividadBL.Buscar(new () {
                    TotalRegistros = 20,
                    NumeroPagina = 1
                });
                if (resp.Any())
                {
                    actividades = new ObservableCollection<ActividadDto>(resp);

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

        private async Task MostrarError(string message)
        {
        }

        [RelayCommand]
        private  Task Buscar()
        {
            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                //// Simular búsqueda de actividades (aquí puedes hacer la llamada al servicio REST)
                //var resultados = await ServicioRest.BuscarActividadesAsync(TextoBusqueda);
                //Actividades = new ObservableCollection<ActividadDto>(resultados);
            }
            return Task.CompletedTask;
        }
    }
}

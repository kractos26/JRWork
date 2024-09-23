
using JWork.UI.Administracion.Mobile.Views;

using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using JWork.UI.Administracion.Common;
using CommunityToolkit.Mvvm.ComponentModel;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
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
            if (e.PropertyName == nameof(Actividadselecionada))
            {
                string uri = $"{nameof(ActividadPage)}?id={Actividadselecionada.ActividadId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<ActividadDto> resp = await _actividadBL.Buscar(new () {
                    Entidad = new(),
                    TotalRegistros = 20,
                    NumeroPagina = 1
                });
                if (resp.Any())
                {
                    Actividades = new ObservableCollection<ActividadDto>(resp);

                }
            }
            catch(JWorkException ex)
            {
                await GlobalAlertas.Error(ex.Message);
            }
            catch (Exception)
            {
            }
        }



        [RelayCommand]
        private  Task Buscar()
        {
            if (!string.IsNullOrWhiteSpace(TextoBusqueda))
            {
                //// Simular búsqueda de actividades (aquí puedes hacer la llamada al servicio REST)
                //var resultados = await ServicioRest.BuscarActividadesAsync(TextoBusqueda);
                //Actividades = new ObservableCollection<ActividadDto>(resultados);
            }
            return Task.CompletedTask;
        }
    }
}

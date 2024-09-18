using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
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
            Common.Response<List<ActividadDto>> resp = await _actividadBL.Buscar(new ActividadRequest() { });
            if (resp.Entidad != null) 
            {
                actividades = new ObservableCollection<ActividadDto>(resp.Entidad);

            }
        }

        [RelayCommand]
        private async Task Buscar()
        {
            // Lógica de búsqueda de actividades basadas en el texto de búsqueda
            if (!string.IsNullOrWhiteSpace(textoBusqueda))
            {
                //// Simular búsqueda de actividades (aquí puedes hacer la llamada al servicio REST)
                //var resultados = await ServicioRest.BuscarActividadesAsync(TextoBusqueda);
                //Actividades = new ObservableCollection<ActividadDto>(resultados);
            }
        }
    }
}

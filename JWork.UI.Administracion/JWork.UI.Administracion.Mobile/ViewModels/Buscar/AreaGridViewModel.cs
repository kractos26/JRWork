using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Mobile.Service;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class AreaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        private string? textoBusqueda;

        [ObservableProperty]
        private ObservableCollection<AreaDto> areas;

        [ObservableProperty]
        private AreaDto areaSeleccionada;

        [ObservableProperty]
        private string iconModal = "add_circle";  // Default value

        [ObservableProperty]
        private Color iconColor = Colors.Green;

        private readonly AreaBL _areaBL;
        private readonly INavigationService _navigationService;
        private readonly PopupService _popupService;
        private readonly IServiceProvider _serviceProvider;

        public AreaGridViewModel(AreaBL areaBL, INavigationService navigationService,
            PopupService popupService, IServiceProvider serviceProvider)
        {
            _areaBL = areaBL;
            _navigationService = navigationService;
            _popupService = popupService;
            _serviceProvider = serviceProvider;

            areas = new ObservableCollection<AreaDto>();
            AreaSeleccionada = new AreaDto();

            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AreaSeleccionada) && AreaSeleccionada != null)
            {
                string uri = $"{nameof(AreaPopup)}?id={AreaSeleccionada.AreaId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<AreaDto> resp = await _areaBL.Buscar(new()
                {Entidad = new(),
                    NumeroPagina = 1,
                    TotalRegistros = 20
                });
                if (resp.Count != 0)
                {
                    Areas = new ObservableCollection<AreaDto>(resp);
                }
            }
            catch (JWorkException ex)
            {
                await GlobalAlertas.Error(ex.Message);
            }
            catch (Exception)
            {
                // Handle errors appropriately
            }
        }


        [RelayCommand]
        private async Task Crear()
        {
            try
            {
                // Obtén el popup desde el service provider
                AreaPopup popup = _serviceProvider.GetRequiredService<AreaPopup>();

                if (popup != null)
                {
                    Shell.Current.ShowPopup(popup);

                    popup.Closed += async (s, e) =>
                    {
                        
                        await RefreshAreas();
                        
                    };

                    popup.Opened += (s, e) =>
                    {
                        IconModal = "cancelar";
                        IconColor = Colors.Red;
                    };
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {

                await Shell.Current.DisplayAlert("❌ Erro", ex.Message, "Ok");

            }
        }

        private async Task RefreshAreas()
        {
           await ObtenerData();
        }
    }
}

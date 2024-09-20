using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui;
using JWork.UI.Administracion.Common;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class AreaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        private string? _textoBusqueda;

        [ObservableProperty]
        private ObservableCollection<AreaDto> _areas;

        [ObservableProperty]
        private AreaDto _areaSeleccionada;

        [ObservableProperty]
        private string _iconModal = "add_circle";  // Default value

        [ObservableProperty]
        private Color _iconColor = Colors.Green;

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

            _areas = new ObservableCollection<AreaDto>();
            _areaSeleccionada = new AreaDto();

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
                {
                    NumeroPagina = 1,
                    TotalRegistros = 20
                });
                if (resp.Any())
                {
                    Areas = new ObservableCollection<AreaDto>(resp);
                }
            }
            catch(JWorkExecectioncs ex)
            {
                await MostrarExepcion(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
            }
        }

        private async Task MostrarExepcion(string message)
        {
        }

        [RelayCommand]
        private async Task Crear()
        {
            try
            {
                var popup = _serviceProvider.GetRequiredService<AreaPopup>();

                popup.Closed += (s, e) =>
                {
                    IconModal = "add_circle";
                    IconColor = Colors.Green;
                };
                popup.Opened += (s, e) =>
                {
                    IconModal = "cancelar";
                    IconColor = Colors.Red;
                };

                Application.Current.MainPage.ShowPopup(popup);
            }
            catch (Exception ex)
            {
                // Handle errors appropriately
            }
        }
    }
}

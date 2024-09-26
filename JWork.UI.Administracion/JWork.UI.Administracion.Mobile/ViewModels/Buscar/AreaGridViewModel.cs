using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Common;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class AreaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        private string textoBusqueda = null!;

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

        private AreaPopup? _popup; // Mantener la referencia al popup actual

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
                await AbrirModal();
            }
        }

        public async Task ObtenerData()
        {
            try
            {
                List<AreaDto> resp = await _areaBL.Buscar(new()
                {
                    Entidad = new()
                    {
                        Nombre = TextoBusqueda
                    },
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
            catch (Exception ex)
            {
                await Shell.Current.DisplaySnackbar(ex.Message);
            }
        }

        [RelayCommand]
        private async Task Editar(AreaDto area)
        {
            try
            {
                AreaSeleccionada = area;
                await AbrirModal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [RelayCommand]
        private async Task Crear()
        {
            AreaSeleccionada = new AreaDto();
            await AbrirModal();
        }

        private async Task AbrirModal()
        {
            try
            {
                // Verificar si ya hay un popup abierto
                if (_popup != null)
                {
                    return; // Si ya hay un popup abierto, no hacemos nada
                }

                AreaViewModel viewModel = _serviceProvider.GetRequiredService<AreaViewModel>();

                // Si seleccionamos un área existente, llenamos los campos
                if (AreaSeleccionada.AreaId > 0)
                {
                    viewModel.AreaId = AreaSeleccionada.AreaId;
                    viewModel.Nombre = AreaSeleccionada.Nombre;
                    viewModel.Mensaje = string.Empty;
                    _popup = new AreaPopup(viewModel);
                }
                else
                {
                    // Si no hay área seleccionada, abrimos un popup para crear una nueva
                    _popup = _serviceProvider.GetRequiredService<AreaPopup>();
                }

                // Evento para manejar el cierre del popup
                _popup.Closed += async (s, e) =>
                {
                    _popup = null; // Limpiar la referencia al cerrar
                    await RefreshAreas();
                };

                Shell.Current.ShowPopup(_popup); // Mostrar el popup
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("❌ Error", ex.Message, "Ok");
            }
        }

        private async Task RefreshAreas()
        {
            await ObtenerData();
        }

        [RelayCommand]
        public async Task Buscar()
        {
            await ObtenerData();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            // Cerrar cualquier popup abierto al navegar
            if (_popup != null)
            {
                _popup.Close();
                _popup = null;
            }
        }
    }
}

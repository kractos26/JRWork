using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Mobile.Service;
using JWork.UI.Administracion.Mobile.Views;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.Mobile.ViewModels.Buscar
{
    public partial class OficioGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<OficioDto> oficios;

        [ObservableProperty]
        public OficioDto oficioseleccionado;

        [ObservableProperty]
        public string? mensaje;
        private readonly OficioBL _oficioBL;

        [ObservableProperty]
        private string textoBusqueda = null!;

        private readonly PopupService _popupService;
        private readonly INavigationService _navigationService;
        private readonly IServiceProvider _serviceProvider;
        private OficioPopup? _popup;
        public OficioGridViewModel(OficioBL oficioBL,
            INavigationService navigationService, PopupService popupService, IServiceProvider serviceProvider)
        {
            _oficioBL = oficioBL;
            oficios = [];
            _navigationService = navigationService;
            oficioseleccionado = new();
            _popupService = popupService;
            _serviceProvider = serviceProvider;
        }



        public async Task ObtenerData()
        {
            try
            {
                List<OficioDto> resp = await _oficioBL.Buscar(new()
                {
                    Entidad = new()
                    {
                        Nombre = TextoBusqueda
                    },
                    TotalRegistros = 20,
                    NumeroPagina = 1,
                });
                if (resp.Count != 0)
                {
                    Oficios = new ObservableCollection<OficioDto>(resp);

                }
            }
            catch (Exception ex)
            {

                Mensaje = $"ocurrio un error {ex.Message}";
            }
        }

        public async Task Buscar()
        {
            await ObtenerData();
        }

        [RelayCommand]
        private async Task Editar(OficioDto oficio)
        {
            try
            {
                Oficioseleccionado = oficio;
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
            Oficioseleccionado = new OficioDto();
            await AbrirModal();
        }

        private async Task AbrirModal()
        {
            try
            {
                if (_popup != null)
                {
                    return;
                }

                OficioViewModel viewModel = _serviceProvider.GetRequiredService<OficioViewModel>();

                if (Oficioseleccionado.OficioId > 0)
                {
                    viewModel.AreaId = Oficioseleccionado.AreaId;
                    viewModel.OficioName = Oficioseleccionado.Nombre;
                    viewModel.OficioId = Oficioseleccionado.OficioId;
                    await viewModel.InicializarAsync();
                    _popup = new OficioPopup(viewModel);
                }
                else
                {
                    await viewModel.InicializarAsync();
                    _popup = new OficioPopup(viewModel);
                }

                _popup.Closed += async (s, e) =>
                {
                    _popup = null;
                    await RefreshAreas();
                };

                Shell.Current.ShowPopup(_popup);
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
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class AreaGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<AreaDto> areas;

        [ObservableProperty]
        public AreaDto arealecionada;

        private readonly AreaBL _areaBL;
        private readonly INavigationService _navigationService;

        public AreaGridViewModel(AreaBL areaBL, INavigationService navigationService)
        {
            _areaBL = areaBL;
            _navigationService = navigationService  ;
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(arealecionada))
            {
                string uri = $"{nameof(AreaPage)}?id={arealecionada.AreaId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<AreaDto>> resp = await _areaBL.Buscar(new AreaDto() { });
            if (resp.Entidad != null) 
            {
                areas = new ObservableCollection<AreaDto>(resp.Entidad);

            }
        }
    }
}

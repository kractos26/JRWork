using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.AppMobile.Services;
using JWork.UI.Administracion.AppMobile.Views;
using JWork.UI.Administracion.Business;
using JWork.UI.Administracion.Models;
using System.Collections.ObjectModel;

namespace JWork.UI.Administracion.AppMobile.ViewModels.Buscar
{
    public partial class ConceptoCalificacionGridViewModel : ViewModelGlobal
    {
        [ObservableProperty]
        public ObservableCollection<ConceptoCalificacionDto> conceptosCalificacion;

        [ObservableProperty]
        public ConceptoCalificacionDto conceptoCalificacionselecionada;

        private readonly ConceptoCalificacionBL _conceptoCalificacionBL;
        private readonly INavigationService _navigationService;
        public ConceptoCalificacionGridViewModel(ConceptoCalificacionBL conceptoCalificacionBL,
            INavigationService navigationService)
        {
            _conceptoCalificacionBL = conceptoCalificacionBL;
            _navigationService = navigationService;
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private async void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(conceptoCalificacionselecionada))
            {

                string uri = $"{nameof(ConceptoCalificacionPage)}?id={conceptoCalificacionselecionada.ConceptoCalificacionId}";
                await _navigationService.GotoAsync(uri);
            }
        }

        public async Task ObtenerData()
        {
            Common.Response<List<ConceptoCalificacionDto>> resp = await _conceptoCalificacionBL.Buscar(new ConceptoCalificacionDto() { });
            if (resp.Entidad != null) 
            {
                conceptosCalificacion = new ObservableCollection<ConceptoCalificacionDto>(resp.Entidad);

            }
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
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
        public ConceptoCalificacionGridViewModel(ConceptoCalificacionBL conceptoCalificacionBL)
        {
            _conceptoCalificacionBL = conceptoCalificacionBL;
            conceptoCalificacionselecionada = new ();
            conceptosCalificacion = [];
            PropertyChanged += AreaGridViewModel_PropertyChanged;
        }

        private void AreaGridViewModel_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(conceptoCalificacionselecionada))
            { 
                
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

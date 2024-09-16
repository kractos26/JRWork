using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Models;

namespace JWork.UI.Administracion.AppMobile.ViewModels
{
    public partial class ConceptoCalificacionViewModel : ViewModelGlobal
    {
        private readonly ConceptoCalificacionDto _conCalificacion;
        public ConceptoCalificacionViewModel()
        {
            _conCalificacion = new ConceptoCalificacionDto();
        }

        [ObservableProperty]
        public int conceptoCalificacionId;
        

        [ObservableProperty]
        public string? nombre;
        

        [ObservableProperty]
        public string? descripcion;
       
    }
}

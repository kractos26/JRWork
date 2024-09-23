namespace JWork.UI.Administracion.Common;

public interface IDatabaseRutaService
{
    public string GetRuta(string archivo);
    public string GetRuta();
    public void AjustePermisos(string archivo,object activity);
    Task SolicitarPermisos(Object activity);
  
}



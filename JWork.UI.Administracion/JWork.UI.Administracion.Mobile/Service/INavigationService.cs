namespace JWork.UI.Administracion.Mobile.Service
{
    public interface INavigationService
    {
        Task GotoAsync(string url);
        Task GotoAsync(string url, IDictionary<string, Object> parametters);
    }
}

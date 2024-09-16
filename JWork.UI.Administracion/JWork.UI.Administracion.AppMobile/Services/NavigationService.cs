namespace JWork.UI.Administracion.AppMobile.Services
{
    public class NavigationService : INavigationService
    {
        public async Task GotoAsync(string url)
        {
            await Shell.Current.GoToAsync(url);
        }

        public async Task GotoAsync(string url, IDictionary<string, object> parametters)
        {
            await Shell.Current.GoToAsync(url,parametters);
        }
    }
}

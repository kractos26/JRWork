using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using an = Android;
namespace JWork.UI.Administracion.Mobile.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override async void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Instanciar DatabaseRutaService
            DatabaseRutaService databaseRutaService = new();

           

        }

        

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            DatabaseRutaService databaseRutaService = new();

            databaseRutaService.AjustePermisos(databaseRutaService.GetRuta("jwork.db"), this);
            if (requestCode == 0)
            {
                // Verifica si los permisos fueron concedidos
                if (grantResults.Length > 0 && grantResults[0] == Permission.Granted)
                {
                    Console.WriteLine("Permisos concedidos.");
                }
                else
                {
                    Console.WriteLine("Permisos denegados.");
                }
            }
        }
    }
}

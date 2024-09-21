/* [grial-metadata] id: Grial#App.xaml version: 1.1.3 */
using JRWork.Administracion.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace JWork.UI.Administracion.Mobile
{
    public partial class App : Application
    {
        private readonly JrworkContext _context;
        public App(JrworkContext context)
        {
            _context = context;

            SQLitePCL.Batteries.Init();
          


            try
            {
                _context.Database.Migrate();
                bool created = _context.Database.EnsureCreated();
                Console.WriteLine($"Database created: {created}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database: {ex.Message}");
            }

            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            UserAppTheme = AppTheme.Light;
            MainPage = new AppShell();

            InitializeComponent();
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception? ex = e.ExceptionObject as Exception;
            HandleException(ex ?? new Exception());
        }

        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleException(e.Exception);
            e.SetObserved();
        }

        private void HandleException(Exception ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Error: {ex.Message}");

                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await MainPage.DisplayAlert("Error", "Ha ocurrido un error inesperado.", "OK");
                });
            }
        }
    }
}

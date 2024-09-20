using JRWork.Administracion.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace JWork.UI.Administracion.AppMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            using (var db = new JrworkContext())
            {
                db.Database.Migrate();  // Crea la base de datos si no existe
            }
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            Application.Current.UserAppTheme = AppTheme.Light; 
            MainPage = new AppShell();
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            HandleException(ex);
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
                    await Application.Current.MainPage.DisplayAlert("Error", "Ha ocurrido un error inesperado.", "OK");
                });
            }
        }
    }
}

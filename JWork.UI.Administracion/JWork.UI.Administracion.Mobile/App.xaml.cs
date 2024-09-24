namespace JWork.UI.Administracion.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            if (OnUnobservedTaskException != null)
            {
                TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            }

            // Configurar el tema de la app
            UserAppTheme = AppTheme.Light;

            // Establecer la MainPage
            MainPage = new AppShell();
        }



        // Manejo de excepciones no controladas
        private void OnUnhandledException(object? sender, UnhandledExceptionEventArgs? e)
        {
            if (e?.ExceptionObject is Exception ex)
            {
                HandleException(ex);
            }
        }

        private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            HandleException(e.Exception);
            e.SetObserved();
        }

        private static void HandleException(Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await Shell.Current.DisplayAlert("Error", "Ha ocurrido un error inesperado.", "OK");
            });
        }
    }
}

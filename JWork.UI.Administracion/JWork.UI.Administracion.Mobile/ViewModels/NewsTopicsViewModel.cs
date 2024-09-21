using Android.AdServices.Topics;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using JWork.UI.Administracion.Mobile;
using System.Collections.ObjectModel;

public partial class NewsTopicsViewModel : ObservableObject
{
    public NewsTopicsViewModel()
    {
        // Inicializa la colecci�n antes de utilizarla
        Topics = new ObservableCollection<NewsTopicData>();
        LoadData();
        TopicTappedCommand = new Command<NewsTopicData>(GoToTopic);
    }

    // Comando para manejar el tap en un tema
    public Command TopicTappedCommand { get; }

    // ObservableCollection para los datos de los temas
    [ObservableProperty]
    private ObservableCollection<NewsTopicData> topics;

    // M�todo que se ejecuta cuando un tema es seleccionado
    private void GoToTopic(NewsTopicData topic)
    {
        if (topic == null) return; // Aseg�rate de que el tema no sea nulo

        // Muestra un popup con informaci�n sobre el tema
        var popup = new Popup
        {
            Content = new Label
            {
                Text = $"Topic '{topic.SectionTitle}' has been tapped.",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 16
            }
        };

        // Verifica si Application.Current.MainPage es compatible con Popup
        Application.Current?.MainPage?.ShowPopup(popup);
    }

    // M�todo para cargar datos desde el archivo JSON
    private void LoadData()
    {
        try
        {
            Topics.Clear();
            JsonHelper.Instance.LoadViewModel(this, source: "News.json", pageName: "NewsTopicsPage.xaml");
        }
        catch (Exception ex)
        {
            // Manejo de errores durante la carga de datos
            Console.WriteLine($"Error loading data: {ex.Message}");
        }
    }
}

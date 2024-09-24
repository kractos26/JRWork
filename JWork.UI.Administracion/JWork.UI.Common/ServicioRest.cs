using System.Collections.Specialized;
using System.Text;
using System.Text.Json;
using System.Web;

namespace JWork.UI.Administracion.Common
{
    public enum Verbo
    {
        Post,
        Get,
        Put,
        Delete
    }

    public class ParametrosServicio
    {
        public string UrlBase { set; get; } = null!;
        public string? Metodo { set; get; }
        public Verbo Verbo { set; get; }
        public bool ValidarSertificado { set; get; }
        public Dictionary<string, object>? Encabezado { set; get; }
        public object? Parametros { get; set; }
    }

    public class ServicioRest
    {
        public static async Task<T?> EjecutarServicioAsync<T>(ParametrosServicio request)
        {

            HttpClient client = InicializarCliente(request.Encabezado, request.ValidarSertificado, request.UrlBase);

            return request.Verbo switch
            {
                Verbo.Get => await EjecutarServicioGetAsync<T>(request.UrlBase, request.Metodo, request.Parametros, client),
                Verbo.Post => await EjecutarServicioPostAsync<T>(request.UrlBase, request.Metodo, request.Parametros, client),
                Verbo.Put => await EjecutarServicioPutAsync<T>(request.UrlBase, request.Metodo, request.Parametros, client),
                Verbo.Delete => await EjecutarServicioDeleteAsync<T>(request.UrlBase, request.Metodo, request.Parametros, client),
                _ => throw new InvalidOperationException("Verbo no válido"),
            };
        }

        private static async Task<T?> EjecutarServicioGetAsync<T>(string? urlBase, string? metodo, object? parametros, HttpClient client)
        {

            UriBuilder urlBuilder = new($"{urlBase}/{metodo}");
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

            if (parametros != null)
            {
                foreach (var prop in parametros.GetType().GetProperties())
                {
                    query[prop.Name] = prop.GetValue(parametros)?.ToString();
                }
                urlBuilder.Query = query.ToString();
            }
            HttpResponseMessage response = await client.GetAsync(urlBuilder.ToString());
            response.EnsureSuccessStatusCode();
            return await ProcesarRespuesta<T>(response);

        }

        private static async Task<T?> EjecutarServicioPostAsync<T>(string? urlBase, string? metodo, object? parametros, HttpClient client)
        {
            string jsonContent = JsonSerializer.Serialize(parametros);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{urlBase}/{metodo}", content);
            return await ProcesarRespuesta<T>(response);
        }

        private static async Task<T?> EjecutarServicioPutAsync<T>(string? urlBase, string? metodo, object? parametros, HttpClient client)
        {
            string jsonContent = JsonSerializer.Serialize(parametros);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"{urlBase}/{metodo}", content);
            return await ProcesarRespuesta<T>(response);
        }

        private static async Task<T?> EjecutarServicioDeleteAsync<T>(string? urlBase, string? metodo, object? parametros, HttpClient client)
        {
            UriBuilder urlBuilder = new($"{urlBase}/{metodo}");
            if (parametros != null)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                foreach (var prop in parametros.GetType().GetProperties())
                {
                    query[prop.Name] = prop.GetValue(parametros)?.ToString();
                }
                urlBuilder.Query = query.ToString();
            }

            HttpResponseMessage response = await client.DeleteAsync(urlBuilder.ToString());
            return await ProcesarRespuesta<T>(response);
        }

        private static async Task<T?> ProcesarRespuesta<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string resultContent = await response.Content.ReadAsStringAsync();
                return !string.IsNullOrWhiteSpace(resultContent) ? JsonSerializer.Deserialize<T>(resultContent) : default;
            }
            else
            {
                // Opcional: manejar errores de una manera más detallada
                throw new HttpRequestException($"Error en la solicitud: {response.StatusCode}");
            }
        }

        private static HttpClient InicializarCliente(Dictionary<string, object>? encabezados, bool validarCertificadoServidor, string urlbase)
        {

            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true; // Solo para pruebas

            HttpClient client = new HttpClient(handler)
            {
                BaseAddress = new Uri(urlbase), // Ajusta la URL según sea necesario
                Timeout = TimeSpan.FromSeconds(300)
            };

            client.DefaultRequestHeaders.Accept.Clear();
            return client;
        }

    }
}

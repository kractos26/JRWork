using System.Collections.Specialized;
using System.Net;
using System.Net.Security;
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
        public string? UrlBase { set; get; }
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
            HttpClient client = new()
            {
                Timeout = TimeSpan.FromSeconds(300.0)
            };
            InicializarCliente(request.Encabezado, request.ValidarSertificado, client);

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
            if (parametros != null)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                foreach (var prop in parametros.GetType().GetProperties())
                {
                    query[prop.Name] = prop.GetValue(parametros)?.ToString();
                }
                urlBuilder.Query = query.ToString();
            }

            HttpResponseMessage response = await client.GetAsync(urlBuilder.ToString());
            string resultContent = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrWhiteSpace(resultContent) ? JsonSerializer.Deserialize<T>(resultContent) : default;
        }

        private static async Task<T?> EjecutarServicioPostAsync<T>(string? urlBase, string? metodo, object? parametros, HttpClient client)
        {
            string jsonContent = JsonSerializer.Serialize(parametros);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"{urlBase}/{metodo}", content);
            string resultContent = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrWhiteSpace(resultContent) ? JsonSerializer.Deserialize<T>(resultContent) : default;
        }

        private static async Task<T?> EjecutarServicioPutAsync<T>(string? urlBase, string? metodo, object? parametros, HttpClient client)
        {
            string jsonContent = JsonSerializer.Serialize(parametros);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"{urlBase}/{metodo}", content);
            string resultContent = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrWhiteSpace(resultContent) ? JsonSerializer.Deserialize<T?>(resultContent) : default;
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
            string resultContent = await response.Content.ReadAsStringAsync();
            return !string.IsNullOrWhiteSpace(resultContent)? JsonSerializer.Deserialize<T>(resultContent):default;
        }

        private static void InicializarCliente(Dictionary<string, object>? encabezados, bool validarCertificadoServidor, HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            if (validarCertificadoServidor)
            {
                ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)((sender, certificate, chain, sslPolicyErrors) => true);
            }
            if (encabezados != null)
            {
                foreach (var encabezado in encabezados)
                {
                    client.DefaultRequestHeaders.Add(encabezado.Key, Convert.ToString(encabezado.Value));
                }
            }
        }
    }
}



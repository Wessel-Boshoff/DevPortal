using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WebAppPortalSite.Common.Options;

namespace WebAppPortalApiService
{
    public class ApiService
    {
        private readonly HttpClient httpClient;

        public ApiService(HttpClient httpClient, IOptions<ApiServiceOptions> options)
        {
            var apiOptions = options.Value;

            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri(apiOptions.BaseUrl);
            this.httpClient.Timeout = TimeSpan.FromSeconds(apiOptions.TimeoutSeconds);
        }

        private void SetAuthHeader(string? token)
        {
            if (!string.IsNullOrEmpty(token))
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            else
                httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<T?> Delete<T>(string endpoint, CancellationToken cancellationToken, string? token = null)
        {
            SetAuthHeader(token);

            var response = await httpClient.DeleteAsync(endpoint, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<T?> Get<T>(string endpoint, CancellationToken cancellationToken, string? token = null)
        {
            SetAuthHeader(token);

            var response = await httpClient.GetAsync(endpoint, cancellationToken);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TResponse?> Put<TRequest, TResponse>(string endpoint, TRequest data, CancellationToken cancellationToken, string? token = null)
        {
            SetAuthHeader(token);

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(endpoint, content, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<TResponse?> Post<TRequest, TResponse>(string endpoint, TRequest data, CancellationToken cancellationToken, string? token = null)
        {
            SetAuthHeader(token);

            var json = JsonSerializer.Serialize(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(endpoint, content, cancellationToken);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<TResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}

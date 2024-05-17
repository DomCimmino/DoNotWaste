using System.Net.Http.Headers;
using System.Text;
using Microsoft.Extensions.Options;

namespace DoNotWaste.Authentication;

public class AuthenticationService(IHttpClientFactory httpClientFactory, IOptions<Configuration> secrets) : IAuthenticationService
{
    private string? _token;

    public async Task<string?> GetToken()
    {
        if (!string.IsNullOrEmpty(_token)) return _token;

        var username = secrets.Value.Username;
        var password = secrets.Value.Password;
        var authHeader = CreateBasicAuthenticationHeader(username ?? string.Empty, password ?? string.Empty);
        try
        {
            var tokenEndpoint = secrets.Value.BaseUri;
            var httpClient = httpClientFactory.GetHttpClient();
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(tokenEndpoint ?? string.Empty),
                Headers = { Authorization = authHeader },
                Content = new FormUrlEncodedContent(
                    new Dictionary<string, string>
                    {
                        { "grant_type", "client_credentials" },
                        { "scope", "supply.domain" }
                    })
            };

            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            _token = authHeader.Parameter;
        }
        catch (HttpRequestException exception)
        {
            _token = null;
            throw;
        }

        return _token;
    }

    private static AuthenticationHeaderValue CreateBasicAuthenticationHeader(string clientId, string clientSecret)
    {
        var credential = $"{clientId}:{clientSecret}";
        var encodedCredential = Convert.ToBase64String(Encoding.UTF8.GetBytes(credential));
        return new AuthenticationHeaderValue("Basic", encodedCredential);
    }
}
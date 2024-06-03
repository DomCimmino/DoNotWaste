using DoNotWaste.Authentication;
using Microsoft.Extensions.Options;

namespace DoNotWaste.Rest;

public class RestClient(
    IAuthenticationService authenticationService,
    IHttpClientFactory httpClientFactory,
    IOptions<Configuration> secrets) : IHttpClient
{
    public async Task<HttpClient> GetHttpClient()
    {
        var token = await authenticationService.GetToken();

        if (string.IsNullOrEmpty(token))
            throw new ArgumentException("Invalid token");

        return await GetHttpClient(new Uri(secrets.Value.EnergyStarUri ?? string.Empty), token);
    }

    public Task<HttpClient> GetHttpClient(Uri baseUri, string? token = null)
    {
        var client = !string.IsNullOrEmpty(token) ? httpClientFactory.GetHttpClient(new RestHttpClientHandler(token)) : httpClientFactory.GetHttpClient();
        client.BaseAddress = baseUri;
        return Task.FromResult(client);
    }
}
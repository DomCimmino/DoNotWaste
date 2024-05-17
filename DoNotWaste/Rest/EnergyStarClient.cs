using DoNotWaste.Authentication;
using Microsoft.Extensions.Options;

namespace DoNotWaste.Rest;

public class EnergyStarClient(
    IAuthenticationService authenticationService,
    IHttpClientFactory httpClientFactory,
    IOptions<Configuration> secrets) : IHttpClient
{
    public async Task<HttpClient> GetHttpClient()
    {
        var token = await authenticationService.GetToken();

        if (string.IsNullOrEmpty(token))
            throw new ArgumentException("Invalid token");

        return await GetHttpClient(new Uri(secrets.Value.BaseUri ?? string.Empty), token);
    }

    public Task<HttpClient> GetHttpClient(Uri baseUri, string token)
    {
        var client = httpClientFactory.GetHttpClient(new RestHttpClientHandler(token));
        client.BaseAddress = baseUri;
        return Task.FromResult(client);
    }
}
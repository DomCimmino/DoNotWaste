using DoNotWaste.Authentication;
using Microsoft.Extensions.Options;

namespace DoNotWaste.Rest;

public class RestClient(
    IAuthenticationService authenticationService,
    IHttpClientFactory httpClientFactory,
    IOptions<Configuration> secrets) : IHttpClient
{
    public async Task<HttpClient> GetHttpClient(bool isXmlRequest = true)
    {
        var token = isXmlRequest
            ? await authenticationService.GetEnergyStarToken()
            : await authenticationService.GetAssetScoreToken();

        if (string.IsNullOrEmpty(token))
            throw new ArgumentException("Invalid token");

        return await GetHttpClient(
            new Uri(isXmlRequest
                ? secrets.Value.EnergyStarUri ?? string.Empty
                : secrets.Value.AssetScoreUri ?? string.Empty), token);
    }

    public Task<HttpClient> GetHttpClient(Uri baseUri, string? token = null)
    {
        var client = !string.IsNullOrEmpty(token)
            ? httpClientFactory.GetHttpClient(new RestHttpClientHandler(token))
            : httpClientFactory.GetHttpClient();
        client.BaseAddress = baseUri;
        return Task.FromResult(client);
    }
}
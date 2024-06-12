using System.Net.Http.Headers;
using System.Text;
using DoNotWaste.Models.AssetScoreModels.Request;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using Microsoft.Extensions.Options;

namespace DoNotWaste.Authentication;

public class AuthenticationService(
    IHttpClientFactory httpClientFactory,
    IOptions<Configuration> secrets)
    : IAuthenticationService
{
    private string? _energyStarToken;
    private string? _assetScoreToken;

    public async Task<string?> GetEnergyStarToken()
    {
        if (!string.IsNullOrEmpty(_energyStarToken)) return _energyStarToken;

        var username = secrets.Value.EnergyStarUsername;
        var password = secrets.Value.EnergyStarPassword;
        var authHeader = CreateBasicAuthenticationHeader(username ?? string.Empty, password ?? string.Empty);
        try
        {
            var tokenEndpoint = secrets.Value.EnergyStarUri;
            var client = httpClientFactory.GetHttpClient();
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

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            _energyStarToken = authHeader.Parameter;
        }
        catch (HttpRequestException exception)
        {
            _energyStarToken = null;
            throw;
        }

        return _energyStarToken;
    }

    public async Task<string?> GetAssetScoreToken()
    {
        if (!string.IsNullOrEmpty(_assetScoreToken)) return _assetScoreToken;
        try
        {
            var request = new AuthenticationRequest
            {
                Email = secrets.Value.AssetScoreUsername,
                Password = secrets.Value.AssetScorePassword,
                OrganizationToken = secrets.Value.AssetScoreOrganizationToken
            };
            
            var client = httpClientFactory.GetHttpClient();
            client.BaseAddress = new Uri(secrets.Value.AssetScoreUri ?? string.Empty);

            var authenticationResponse =
                await RefitExtensions.For<IUserApi>(client, false).GetAssetScoreToken(request);
            _assetScoreToken = authenticationResponse.Token;
        }
        catch (HttpRequestException exception)
        {
            _assetScoreToken = null;
            throw;
        }

        return _assetScoreToken;
    }

    private static AuthenticationHeaderValue CreateBasicAuthenticationHeader(string clientId, string clientSecret)
    {
        var credential = $"{clientId}:{clientSecret}";
        var encodedCredential = Convert.ToBase64String(Encoding.UTF8.GetBytes(credential));
        return new AuthenticationHeaderValue("Basic", encodedCredential);
    }
}
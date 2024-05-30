namespace DoNotWaste.Rest;

public interface IHttpClient
{
    Task<HttpClient> GetHttpClient(bool isTokenRequired = true);
    Task<HttpClient> GetHttpClient(Uri baseUri, string token);
}
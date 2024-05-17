namespace DoNotWaste.Rest;

public interface IHttpClient
{
    Task<HttpClient> GetHttpClient();
    Task<HttpClient> GetHttpClient(Uri baseUri, string token);
}
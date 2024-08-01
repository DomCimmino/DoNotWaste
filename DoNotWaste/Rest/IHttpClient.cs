namespace DoNotWaste.Rest;

public interface IHttpClient
{
    Task<HttpClient> GetHttpClient(bool isXmlRequest = true);
    Task<HttpClient> GetHttpClient(Uri baseUri, string token);
}
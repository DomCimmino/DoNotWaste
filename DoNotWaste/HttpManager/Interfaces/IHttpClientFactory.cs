namespace DoNotWaste.HttpManager.Interfaces;

public interface IHttpClientFactory
{
    HttpClient GetHttpClient(HttpClientHandler? handler = null);
}
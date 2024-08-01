namespace DoNotWaste.HttpManager;

public class HttpClientFactory : IHttpClientFactory
{
    public HttpClient GetHttpClient(HttpClientHandler? handler = null)
    {
        var httpClient = handler != null ? new HttpClient(handler, true) : new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "client application");
        return httpClient;
    }
    
}
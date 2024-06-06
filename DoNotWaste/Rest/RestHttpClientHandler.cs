using System.Net.Http.Headers;

namespace DoNotWaste.Rest;

public class RestHttpClientHandler(string token) : HttpClientHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var uri = request.RequestUri;
        var unescapedQuery = Uri.UnescapeDataString(uri.Query);
        var userInfo = string.IsNullOrWhiteSpace(uri.UserInfo) ? "" : $"{uri.UserInfo}@";
        var scheme = string.IsNullOrWhiteSpace(uri.Scheme) ? "" : $"{uri.Scheme}://";
        var antiCache = $"{(string.IsNullOrEmpty(unescapedQuery) ? "?" : "&")}anti-cache={DateTime.Now.Ticks}";
        request.RequestUri =
            new Uri($"{scheme}{userInfo}{uri.Authority}{uri.AbsolutePath}{unescapedQuery}{uri.Fragment}{antiCache}");

        var auth = request.Headers.Authorization;
        if (auth != null)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);
        }
        
#if DEBUG
        if (request.Method == HttpMethod.Post)
        {
            var bodyDebug = await request.Content?.ReadAsStringAsync();
        }
#endif
        
        return await base.SendAsync(request, cancellationToken);
    }
}
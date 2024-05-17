using Refit;

namespace DoNotWaste.Rest;

public static class RefitExtensions
{
    public static T For<T>(string hostUrl) => RestService.For<T>(hostUrl, GetXmlRefitSettings());
    public static T For<T>(HttpClient client) => RestService.For<T>(client, GetXmlRefitSettings());

    private static RefitSettings GetXmlRefitSettings() => new (new XmlContentSerializer());
}
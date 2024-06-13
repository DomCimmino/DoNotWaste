using System.Xml;
using Refit;

namespace DoNotWaste.Rest;

public static class RefitExtensions
{
    public static T For<T>(string hostUrl, bool isXmlRequest = true) => RestService.For<T>(hostUrl, isXmlRequest ? GetXmlRefitSettings() : GetJsonRefitSettings());
    public static T For<T>(HttpClient client, bool isXmlRequest = true) => RestService.For<T>(client, isXmlRequest ? GetXmlRefitSettings() : GetJsonRefitSettings());

    private static RefitSettings GetXmlRefitSettings() => new(new XmlContentSerializer(new XmlContentSerializerSettings
    {
        XmlReaderWriterSettings = new XmlReaderWriterSettings(new XmlWriterSettings()
        {
            Async = true,
            Indent = true,
            CloseOutput = true
        })
    }));
    private static RefitSettings GetJsonRefitSettings() => new (new NewtonsoftJsonContentSerializer());
}
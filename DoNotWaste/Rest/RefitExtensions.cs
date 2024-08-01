using System.Xml;
using Newtonsoft.Json;
using Refit;
using Formatting = Newtonsoft.Json.Formatting;

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
    
    private static RefitSettings GetJsonRefitSettings() => new (new NewtonsoftJsonContentSerializer(new JsonSerializerSettings(new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
        Formatting = Formatting.Indented,
    })));
}
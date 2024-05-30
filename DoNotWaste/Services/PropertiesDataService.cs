using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class PropertiesDataService : IPropertiesDataService
{
    public Task DownloadData(string outPath, string? version)
    {
        var fileName = "original_data.zip";
        var filePath = Path.Combine(outPath, fileName);

        if (!File.Exists(filePath))
        {
            var url = $"http://data.open-power-system-data.org/household_data/{version}/original_data/{fileName}";
        }

        return Task.CompletedTask;
    }
}
namespace DoNotWaste.Services.Interfaces;

public interface IPropertiesDataService
{
    public Task DownloadData(string outPat, string? versions);
}
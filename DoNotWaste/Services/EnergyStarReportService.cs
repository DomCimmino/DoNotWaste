using System.Net;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class EnergyStarReportService(IWebHostEnvironment environment, IHttpClient httpClient) : IEnergyStarReportService
{
    public async Task<Dictionary<string, int>> GetReportTypes()
    {
        var response = await RefitExtensions.For<IEnergyStarReportApi>(await httpClient.GetHttpClient())
            .GetReportTypes(Costant.EnergyStarTypeReport);
        return (response.Links?.Link ?? []).ToDictionary(link => link.Hint ?? string.Empty, link => link.Id);
    }

    public async Task<EnergyStarReportStatus> GetReportStatus(int reportId)
    {
        return await RefitExtensions.For<IEnergyStarReportApi>(await httpClient.GetHttpClient())
            .GetReportStatus(reportId);
    }

    public async Task DownloadReport(int reportId)
    {
        var response = await RefitExtensions.For<IEnergyStarReportApi>(await httpClient.GetHttpClient())
            .DownloadReport(reportId, Costant.EnergyStarExtensionFile);

        response.EnsureSuccessStatusCode();

        var fileBytes = await response.Content.ReadAsByteArrayAsync();
        var filePath = Path.Combine(environment.WebRootPath, "data",$"report{reportId}.xlsx");
        if (!File.Exists(filePath)) File.Create(filePath);
        await File.WriteAllBytesAsync(filePath, fileBytes);
    }

    public async Task<EnergyStarResponse> GenerateReport(int reportId)
    {
        return await RefitExtensions.For<IEnergyStarReportApi>(await httpClient.GetHttpClient())
            .GenerateReport(reportId);
    }

    public async Task<EnergyStarResponse> ModifyReport(int reportId, EnergyStarReport report)
    {
        return await RefitExtensions.For<IEnergyStarReportApi>(await httpClient.GetHttpClient())
            .ModifyReport(reportId, report);
    }
}
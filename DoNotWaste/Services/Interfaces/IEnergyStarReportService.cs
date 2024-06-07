using DoNotWaste.Models.EnergyStarModels;

namespace DoNotWaste.Services.Interfaces;

public interface IEnergyStarReportService
{
    Task<Dictionary<string,int>> GetReportTypes();
    Task<EnergyStarReportStatus> GetReportStatus(int reportId);
    Task DownloadReport(int reportId);
    Task<EnergyStarResponse> GenerateReport(int reportId);

    Task<EnergyStarResponse> ModifyReport(int reportId, EnergyStarReport report);
}
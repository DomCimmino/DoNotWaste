using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

[Headers("Authorization: Basic Auth")]
public interface IEnergyStarReportApi
{
    [Get("/reports")]
    Task<EnergyStarResponse> GetReportTypes([Query] string type);

    [Get("/reports/{reportId}/download")]
    Task<HttpResponseMessage> DownloadReport(int reportId, [Query] string type);

    [Get("/reports/{reportId}/status")]
    Task<EnergyStarReportStatus> GetReportStatus(int reportId);

    [Post("/reports/{reportId}/generate")]
    Task<EnergyStarResponse> GenerateReport(int reportId);

    [Put("/reports/{reportId}")]
    Task<EnergyStarResponse> ModifyReport(int reportId, [Body(BodySerializationMethod.Serialized)] EnergyStarReport report);
}
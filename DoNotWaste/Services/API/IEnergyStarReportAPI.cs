using DoNotWaste.Models.EnergyStarModels;
using Refit;

namespace DoNotWaste.Services.API;

[Headers("Authorization: Basic Auth")]
public interface IEnergyStarReportApi
{
    [Get("/reports")]
    Task<EnergyStarResponse> GetReportTypes([Query] string type);

    [Get("/reports/{reportId}/status")]
    Task<EnergyStarReportStatus> GetReportStatus(int reportId);

    [Headers("PM-Metrics: score, scoreMotivationText, siteIntensity")]
    [Get("/property/{propertyId}/metrics")]
    Task<EnergyStarMetric> GetPropertyMetric(int propertyId, [Query] int month, [Query] int year,
        [Query] string measurementSystem);

    [Post("/reports/{reportId}/generate")]
    Task<EnergyStarResponse> GenerateReport(int reportId);

    [Put("/reports/{reportId}")]
    Task<EnergyStarResponse> ModifyReport(int reportId,
        [Body(BodySerializationMethod.Serialized)] EnergyStarReport report);
}
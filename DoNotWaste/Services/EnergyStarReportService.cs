using System.Globalization;
using DoNotWaste.Models.EnergyStarModels;
using DoNotWaste.Rest;
using DoNotWaste.Services.API;
using DoNotWaste.Services.Interfaces;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace DoNotWaste.Services;

public class EnergyStarReportService(IHttpClient httpClient) : IEnergyStarReportService
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


    public async Task<EnergyStarMetric> GetPropertyMetric(int propertyId)
    {
        return await RefitExtensions.For<IEnergyStarReportApi>(await httpClient.GetHttpClient())
            .GetPropertyMetric(propertyId, Costant.EndDate.Month - 1, Costant.EndDate.Year, Costant.MetricType);
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

    public MemoryStream CreatePdf(EnergyStarProperty property, EnergyStarMetric metric)
    {
        var memoryStream = new MemoryStream();
        using var writer = new PdfWriter(memoryStream);
        using var pdf = new PdfDocument(writer);
        var document = new Document(pdf);

        var title = new Paragraph("ENERGY STAR® Statement of Energy Performance")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
            .SetFontSize(20);
        document.Add(title);

        var score = new Paragraph($"ENERGY STAR®\n{metric.Metrics?.FirstOrDefault(x => x.Name == "score")?.Value}")
            .SetTextAlignment(TextAlignment.CENTER)
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD))
            .SetFontSize(18)
            .SetMarginTop(20);
        document.Add(score);

        var scoreMotivation =
            new Paragraph($"{metric.Metrics?.FirstOrDefault(x => x.Name == "scoreMotivationText")?.Value}")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                .SetFontSize(18)
                .SetMarginTop(20);
        document.Add(scoreMotivation);

        var propertyDetails =
            new Paragraph(
                    $"{property.Name}\n\n" +
                    $"Primary Property Type: {property.PrimaryFunction}\n" +
                    $"Gross Floor Area (m²): {property.GrossFloorArea?.Value}\n" +
                    $"Built: {property.YearBuilt}\n\n" +
                    $"For Year Ending: {metric.DateYearEnding().ToString("D", new CultureInfo("en-US"))}\n" +
                    $"Date Generated: {DateTime.UtcNow.ToString("D", new CultureInfo("en-US"))}")
                .SetTextAlignment(TextAlignment.LEFT)
                .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
                .SetFontSize(12)
                .SetMarginTop(20);
        document.Add(propertyDetails);
        
        var propertyInfo = new Paragraph(
                $"Property & Contact Information\n\n" +
                $"Property Address:\n{property.Address?.FirstAddress}\n{property.Address?.City}, {property.Address?.OtherState} {property.Address?.PostalCode}\n\n" +
                $"Property ID: {property.Id}")
            .SetTextAlignment(TextAlignment.LEFT)
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
            .SetFontSize(12)
            .SetMarginTop(20);
        document.Add(propertyInfo);
        
        var energyConsumption = new Paragraph(
                $"Energy Consumption and Energy Use Intensity (EUI)\n\n" +
                $"Site EUI: {metric.Metrics?.FirstOrDefault(x => x.Name == "siteIntensity")?.Value} GJ/m²")
            .SetTextAlignment(TextAlignment.LEFT)
            .SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA))
            .SetFontSize(12)
            .SetMarginTop(20);
        document.Add(energyConsumption);

        document.Close();
        return memoryStream;
    }
}
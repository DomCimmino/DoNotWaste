namespace DoNotWaste.Services.Interfaces;

public interface IChartService
{
    (string[] Labels, double[] Data) GetDataChart();
}
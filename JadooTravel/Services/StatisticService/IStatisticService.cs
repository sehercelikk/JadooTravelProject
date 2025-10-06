namespace JadooTravel.Services.StatisticService;

public interface IStatisticService
{
    Task<int> GetTotalTourCountAsync();
    Task<int> GetTourWithKotaAsync();
    Task<decimal> GetLastFiveTourAsync();
}

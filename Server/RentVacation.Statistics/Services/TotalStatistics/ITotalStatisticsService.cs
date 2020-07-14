using RentVacation.Statistics.Models.TotalStatistics;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Services.TotalStatistics
{
    public interface ITotalStatisticsService
    {
        Task<TotalStatisticsOutputModel> Full();

        Task IncreaseApartaments();
    }
}

using Refit;
using RentVacation.Admin.Models.Statistics;
using System.Threading.Tasks;

namespace RentVacation.Admin.Services.Statistics
{
    public interface IStatisticsService
    {
        [Get("/Statistics")]
        Task<StatisticsOutputModel> Full();
    }
}

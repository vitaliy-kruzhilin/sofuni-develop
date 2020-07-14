using Microsoft.AspNetCore.Mvc;
using RentVacation.Common.Controllers;
using RentVacation.Statistics.Models.TotalStatistics;
using RentVacation.Statistics.Services.TotalStatistics;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Controllers
{
    public class TotalStatisticsController : ApiController
    {
        private readonly ITotalStatisticsService statistics;

        public TotalStatisticsController(ITotalStatisticsService statistics) 
            => this.statistics = statistics;

        [HttpGet]
        public async Task<TotalStatisticsOutputModel> Full()
            => await this.statistics.Full();
    }
}

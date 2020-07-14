using Microsoft.AspNetCore.Mvc;
using RentVacation.Admin.Services.Statistics;
using System.Threading.Tasks;

namespace RentVacation.Admin.Controllers
{
    public class StatisticsController : AdministrationController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics) 
            => this.statistics = statistics;

        public async Task<IActionResult> Index()
            => View(await this.statistics.Full());
    }
}

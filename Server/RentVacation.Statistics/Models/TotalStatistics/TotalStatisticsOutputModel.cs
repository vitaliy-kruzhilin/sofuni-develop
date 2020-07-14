using RentVacation.Common.Models;

namespace RentVacation.Statistics.Models.TotalStatistics
{
    public class TotalStatisticsOutputModel : IMapFrom<TotalStatisticsOutputModel>
    {
        public int TotalCarAds { get; set; }

        public int TotalRentedCars { get; set; }
    }
}

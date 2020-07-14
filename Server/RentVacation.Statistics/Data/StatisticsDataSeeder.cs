using RentVacation.Common.Services.Data;
using RentVacation.Statistics.Data.Models;
using System.Linq;

namespace RentVacation.Statistics.Data
{
    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticsDbContext db;

        public StatisticsDataSeeder(StatisticsDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.TotalStatistics.Any())
            {
                return;
            }

            this.db.TotalStatistics.Add(new TotalStatistics
            {
                TotalApartaments = 0,
                TotalRentedApartaments = 0
            });

            this.db.SaveChanges();
        }
    }
}

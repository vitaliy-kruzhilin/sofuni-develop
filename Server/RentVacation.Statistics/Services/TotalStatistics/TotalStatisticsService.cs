using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RentVacation.Common.Services.Data;
using RentVacation.Statistics.Data;
using RentVacation.Statistics.Models.TotalStatistics;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Services.TotalStatistics
{
    public class TotalStatisticsService : DataService<Data.Models.TotalStatistics>, ITotalStatisticsService
    {
        private readonly IMapper mapper;

        public TotalStatisticsService(StatisticsDbContext db, IMapper mapper) 
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<TotalStatisticsOutputModel> Full()
            => await this.mapper
                .ProjectTo<TotalStatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync();

        public async Task IncreaseApartaments()
        {
            var totalStatistics = await this.All().SingleOrDefaultAsync();

            totalStatistics.TotalApartaments++;

            await this.Data.SaveChangesAsync();
        }
    }
}

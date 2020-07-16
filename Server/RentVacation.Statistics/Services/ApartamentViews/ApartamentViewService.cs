using Microsoft.EntityFrameworkCore;
using RentVacation.Common.Services.Data;
using RentVacation.Statistics.Data;
using RentVacation.Statistics.Data.Models;
using RentVacation.Statistics.Models.ApartamentsViews;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Services.ApartamentViews
{
    public class ApartamentViewService : DataService<ApartamentView>, IApartamentViewService
    {
        public ApartamentViewService(StatisticsDbContext db) : base(db)
        {
        }

        public async Task<int> GetTotalViews(int apartamentId)
            => await this
                .All()
                .CountAsync(v => v.ApartamentId == apartamentId);

        public async Task<IEnumerable<ApartamentViewOutputModel>> GetTotalViews(IEnumerable<int> ids)
            => await this
                .All()
                .Where(v => ids.Contains(v.ApartamentId))
                .GroupBy(v => v.ApartamentId)
                .Select(gr => new ApartamentViewOutputModel
                {
                    ApartamentId = gr.Key,
                    TotalViews = gr.Count()
                })
                .ToListAsync();
    }
}

using RentVacation.Statistics.Models.ApartamentsViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentVacation.Statistics.Services.ApartamentViews
{
    public interface IApartamentViewService
    {
        Task<int> GetTotalViews(int apartamentId);

        Task<IEnumerable<ApartamentViewOutputModel>> GetTotalViews(IEnumerable<int> ids);
    }
}

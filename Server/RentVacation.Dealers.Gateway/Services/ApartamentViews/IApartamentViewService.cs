using Refit;
using RentVacation.Dealers.Gateway.Models.ApartamentViews;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentVacation.Dealers.Gateway.Services.ApartamentViews
{
    public interface IApartamentViewService
    {
        [Get("/ApartamentViews")]
        Task<IEnumerable<ApartamentViewOutputModel>> TotalViews([Query(CollectionFormat.Multi)] IEnumerable<int> ids);
    }
}

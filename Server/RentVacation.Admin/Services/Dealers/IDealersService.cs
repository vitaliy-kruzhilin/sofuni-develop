using Refit;
using RentVacation.Admin.Models.Dealers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentVacation.Admin.Services.Dealers
{
    public interface IDealersService
    {
        [Get("/Dealers")]
        Task<IEnumerable<DealerDetailsOutputModel>> GetAllDealers();

        [Get("/Dealers/{id}")]
        Task<DealerDetailsOutputModel> Details(int id);

        [Put("/Dealers/{id}")]
        Task Edit(int id, DealerInputModel dealer);
    }
}

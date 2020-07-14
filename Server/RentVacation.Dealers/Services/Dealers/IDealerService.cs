using System.Collections.Generic;
using System.Threading.Tasks;
using RentVacation.Dealers.Data.Models;
using RentVacation.Dealers.Models.Dealers;

namespace RentVacation.Dealers.Services.Dealers
{
    public interface IDealerService : IDataService<Dealer>
    {
        Task<Dealer> FindByUser(string userId);

        Task<Dealer> FindById(int Id);

        Task<int> GetIdByUser(string userId);

        Task<bool> HasApartament(int dealerId, int apartamentId);

        Task<bool> IsDealer(string userId);

        Task<DealerDetailsOutputModel> GetDetails(int id);

        Task<IEnumerable<DealerDetailsOutputModel>> GetAllDealers();

        Task<DealerOutputModel> GetDetailsByApartamentId(int apartamnetId);
    }
}

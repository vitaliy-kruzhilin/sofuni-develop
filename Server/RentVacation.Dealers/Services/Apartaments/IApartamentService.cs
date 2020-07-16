using System.Collections.Generic;
using System.Threading.Tasks;
using RentVacation.Common.Services.Data;
using RentVacation.Dealers.Data.Models;
using RentVacation.Dealers.Models.Apartaments;

namespace RentVacation.Dealers.Services.Apartaments
{
    public interface IApartamentService : IDataService<Apartament>
    {
        Task<Apartament> Find(int id);

        Task<bool> Delete(int id);

        Task<IEnumerable<ApartamentOutputModel>> GetListings(ApartamentsQuery query);

        Task<IEnumerable<MineApartamentOutputModel>> Mine(int dealerId, ApartamentsQuery query);

        Task<ApartamentDetailsOutputModel> GetDetails(int id);

        Task<int> Total(ApartamentsQuery query);
    }
}

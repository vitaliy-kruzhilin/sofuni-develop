using Microsoft.EntityFrameworkCore;
using RentVacation.Common.Services.Data;
using RentVacation.Schedule.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Schedule.Services
{
    public class RentedApartamentService : DataService<RentedApartament>, IRentedApartamentService
    {
        public RentedApartamentService(DbContext db) : base(db)
        {
        }

        public async Task UpdateInformation(int apartamentId, string information)
        {
            var rentedApartaments = await this
                .All()
                .Where(w => w.ApartamentId == apartamentId)
                .ToListAsync();

            foreach (var rentedCar in rentedApartaments)
            {
                rentedCar.Information = information;
            }

            await this.Data.SaveChangesAsync();
        }
    }
}

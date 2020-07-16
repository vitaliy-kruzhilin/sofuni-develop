using System.Threading.Tasks;

namespace RentVacation.Schedule.Services
{
    public interface IRentedApartamentService
    {
        Task UpdateInformation(int apartamentId, string information);
    }
}

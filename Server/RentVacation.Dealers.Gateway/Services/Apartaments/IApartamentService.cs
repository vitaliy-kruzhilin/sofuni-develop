using Refit;
using RentVacation.Dealers.Gateway.Models.Apartaments;
using System.Threading.Tasks;

namespace RentVacation.Dealers.Gateway.Services.Apartaments
{
    public interface IApartamentService
    {
        [Get("/Apartaments/Mine")]
        Task<MineApartamentsOutputModel> Mine();
    }
}

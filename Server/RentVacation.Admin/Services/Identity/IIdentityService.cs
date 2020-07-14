using Refit;
using RentVacation.Admin.Models.Identity;
using System.Threading.Tasks;

namespace RentVacation.Admin.Services.Identity
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}

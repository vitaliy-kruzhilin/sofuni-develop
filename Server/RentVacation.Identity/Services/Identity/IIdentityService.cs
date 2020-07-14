using System.Threading.Tasks;
using RentVacation.Identity.Data.Models;
using RentVacation.Identity.Models.Identity;
using RentVacation.Common.Services;

namespace RentVacation.Identity.Services.Identity
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);

        Task<Result> ChangePassword(string userId, ChangePasswordInputModel changePasswordInput);
    }
}

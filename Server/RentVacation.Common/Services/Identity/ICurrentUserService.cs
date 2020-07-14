using Microsoft.AspNetCore.SignalR;

namespace RentVacation.Common.Services.Identity
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAdministrator { get; }
    }
}

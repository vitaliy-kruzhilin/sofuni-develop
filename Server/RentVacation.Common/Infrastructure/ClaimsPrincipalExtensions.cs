using System.Security.Claims;

using static RentVacation.Common.Constants;

namespace RentVacation.Common.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user) => user.IsInRole(AdministratorRoleName);
    }
}

using Microsoft.AspNetCore.Authorization;

namespace RentVacation.Common.Infrastructure
{
    public class AuthorizeAdministratorAttribute: AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = Constants.AdministratorRoleName;
    }
}

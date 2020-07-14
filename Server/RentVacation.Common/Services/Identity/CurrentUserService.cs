using Microsoft.AspNetCore.Http;
using RentVacation.Common.Infrastructure;
using System;
using System.Security.Claims;

namespace RentVacation.Common.Services.Identity
{
    public class CurrentUserService : ICurrentUserService
    {
        private ClaimsPrincipal user;
        
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            this.user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            this.UserId = this.user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public string UserId { get; }

        public bool IsAdministrator => this.user.IsAdministrator();
    }
}

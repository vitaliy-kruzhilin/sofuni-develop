using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RentVacation.Common.Services.Identity;
using System.Linq;
using System.Threading.Tasks;

using static RentVacation.Common.Infrastructure.InfrastructureConstants;

namespace RentVacation.Common.Infrastructure
{
    public class JwtHeaderAuthenticationMiddleware : IMiddleware
    {
        private readonly ICurrentTokenService currentToken;

        public JwtHeaderAuthenticationMiddleware(ICurrentTokenService currentToken) 
            => this.currentToken = currentToken;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var token = context.Request.Headers.TryGetValue(AuthenticationCookieName, out var value) ? value.ToString() : string.Empty;

            if (!string.IsNullOrWhiteSpace(token))
            {
                this.currentToken.Set(token.Split().Last());
            }

            await next.Invoke(context);
        }
    }

    public static class JwtHeaderAuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtHeaderAuthentication(
            this IApplicationBuilder app)
            => app
                .UseMiddleware<JwtHeaderAuthenticationMiddleware>()
                .UseAuthentication();
    }
}

using Microsoft.Extensions.DependencyInjection;
using RentVacation.Common.Services.Data;
using RentVacation.Identity.Data;
using RentVacation.Identity.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentVacation.Identity.Infrastructure
{
    public static class ServiceInterfaceExtensions
    {
        public static IServiceCollection AddClasses(this IServiceCollection services)
            => services
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IDataSeeder, DataSeeder>()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>();
    }
}

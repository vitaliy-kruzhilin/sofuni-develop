using Microsoft.Extensions.DependencyInjection;
using RentVacation.Common.Services.Data;
using RentVacation.Common.Services.Identity;
using RentVacation.Dealers.Data;
using RentVacation.Dealers.Services.Apartaments;
using RentVacation.Dealers.Services.Categories;
using RentVacation.Dealers.Services.Dealers;

namespace RentVacation.Dealers.Infrastructure
{
    public static class ServiceInterfaceExtensions
    {
        public static IServiceCollection AddClasses(this IServiceCollection services)
            => services
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<IDataSeeder, DataSeeder>()
                .AddTransient<IDealerService, DealerService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IApartamentService, ApartamentService>();
    }
}

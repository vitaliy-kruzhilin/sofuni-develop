using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentVacation.Dealers.Services.Apartaments;
using RentVacation.Dealers.Services.Categories;
using RentVacation.Dealers.Services.Dealers;
using RentVacation.Common.Services.Identity;
using RentVacation.Common.Infrastructure;
using RentVacation.Common.Services.Data;
using RentVacation.Dealers.Data;
using MassTransit;

namespace RentVacation.Dealers
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<DealersDbContext>(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddTokenAuthentication(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddScoped<ICurrentUserService, CurrentUserService>()
                .AddTransient<IDataSeeder, DataSeeder>()
                .AddTransient<IDealerService, DealerService>()
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IApartamentService, ApartamentService>()
                .AddMessaging(this.Configuration)
                .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}

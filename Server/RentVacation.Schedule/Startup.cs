using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentVacation.Common.Infrastructure;
using RentVacation.Schedule.Data;
using RentVacation.Schedule.Messages;
using RentVacation.Schedule.Services;
using System.Reflection;

namespace RentVacation.Schedule
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
            => services
                .AddDatabase<ScheduleDbContext>(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddTokenAuthentication(this.Configuration)
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddTransient<IRentedApartamentService, RentedApartamentService>()
                .AddMessaging(
                    this.Configuration,
                    typeof(ApartamentUpdatedConsumer));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}

using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentVacation.Common.Infrastructure;
using RentVacation.Statistics.Data;
using RentVacation.Statistics.Messages;
using RentVacation.Statistics.Services.ApartamentViews;
using RentVacation.Statistics.Services.TotalStatistics;

namespace RentVacation.Statistics
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddWebServices<StatisticsDbContext>(this.Configuration)
                .AddScoped<IApartamentViewService, ApartamentViewService>()
                .AddTransient<ITotalStatisticsService, TotalStatisticsService>()
                .AddMessaging(this.Configuration, typeof(ApartamentCreatedConsumer));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}

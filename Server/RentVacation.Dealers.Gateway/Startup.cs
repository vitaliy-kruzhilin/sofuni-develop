using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentVacation.Common.Infrastructure;
using RentVacation.Dealers.Gateway.Services;
using RentVacation.Common.Services.Identity;
using System.Reflection;
using Refit;
using RentVacation.Dealers.Gateway.Services.Apartaments;
using RentVacation.Dealers.Gateway.Services.ApartamentViews;

namespace RentVacation.Dealers.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var serviceEndpoints = this.Configuration
                .GetSection(nameof(ServiceEndpoints))
                .Get<ServiceEndpoints>(config => config.BindNonPublicProperties = true);

            services
                .AddAutoMapperProfile(Assembly.GetExecutingAssembly())
                .AddTokenAuthentication(this.Configuration)
                .AddScoped<ICurrentTokenService, CurrentTokenService>()
                .AddControllers();

            services
                .AddRefitClient<IApartamentService>()
                .WithConfiguration(serviceEndpoints.Dealers);

            services
                .AddRefitClient<IApartamentViewService>()
                .WithConfiguration(serviceEndpoints.Statistics);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseJwtHeaderAuthentication()
                .UseWebService(env)
                .Initialize();
    }
}

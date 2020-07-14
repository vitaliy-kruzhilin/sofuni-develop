using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;    
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentVacation.Identity.Data.Models;
using RentVacation.Identity.Data;
using RentVacation.Common.Infrastructure;
using RentVacation.Identity.Services.Identity;
using RentVacation.Common.Services.Data;

namespace RentVacation.Identity
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDatabase<IdentityDbContext>(this.Configuration)
                .AddApplicationSettings(this.Configuration)
                .AddTokenAuthentication(this.Configuration)
                .AddTransient<IIdentityService, IdentityService>()
                .AddTransient<IDataSeeder, DataSeeder>()
                .AddTransient<ITokenGeneratorService, TokenGeneratorService>()
                .AddControllers();

            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<IdentityDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app.UseWebService(env).Initialize();
    }
}

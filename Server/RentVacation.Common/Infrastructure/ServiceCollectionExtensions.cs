using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RentVacation.Common.Models;
using RentVacation.Common.Services.Identity;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace RentVacation.Common.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase<TDbContext>(this IServiceCollection services, IConfiguration configuration) where TDbContext : DbContext
            => services
                .AddDbContext<TDbContext>(options => options
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
            => services
                .Configure<ApplicationSettings>(configuration.GetSection(nameof(ApplicationSettings)));

        public static IServiceCollection AddTokenAuthentication(this IServiceCollection services, IConfiguration configuration, JwtBearerEvents events = null)
        {
            var secret = configuration
                .GetSection(nameof(ApplicationSettings))
                .GetValue<string>(nameof(ApplicationSettings.Secret));

            var key = Encoding.ASCII.GetBytes(secret);

            services
                .AddAuthentication(authentication =>
                {
                    authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    if (events != null)
                    {
                        bearer.Events = events;
                    }
                });

            services.AddHttpContextAccessor();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }

        public static IServiceCollection AddAutoMapperProfile(
           this IServiceCollection services,
           Assembly assembly)
           => services
               .AddAutoMapper(
                   (_, config) => config
                       .AddProfile(new MappingProfile(assembly)),
                   Array.Empty<Assembly>());

        public static IServiceCollection AddMessaging(this IServiceCollection services, params Type[] consumers)
            => services
                .AddMassTransit(mt =>
                {
                    foreach (var consumer in consumers)
                    {
                        mt.AddConsumer(consumer);
                    }

                    mt.AddBus(bus => Bus.Factory.CreateUsingRabbitMq(rmq =>
                    {
                        rmq.Host("rabbitmq", host =>
                        {
                            host.Username("rabbitmq");
                            host.Password("rabbitmq");
                        });

                        foreach (var consumer in consumers)
                        {
                            rmq.ReceiveEndpoint(consumer.FullName, endpoint =>
                            {
                                endpoint.ConfigureConsumer(bus, consumer);
                            });
                        }
                    }));
                })
                .AddMassTransitHostedService();
    }
}

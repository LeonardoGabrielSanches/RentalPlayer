using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalSports.Domain.Entities;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.Domain.Provider;
using RentalSports.Domain.Services;
using RentalSports.Infra.Data.MongoDB;
using RentalSports.Infra.Data.MongoDB.Repositories;

namespace RentalSports.WebApi.IoC
{
    public static class RegisterServices
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddSingleton(service =>
            {
                var uri = service.GetRequiredService<IConfiguration>()["MongoUri"];
                return new DBContext(uri);
            });

            services.AddSingleton(service =>
            {
                var secret = service.GetRequiredService<IConfiguration>()["Secret"];
                return new EncryptProvider(secret);
            });

            services.AddSingleton(service =>
            {
                return new UserAuthenticated();
            });

            services.AddScoped<IPlayerRepository, PlayerRepository>();

            services.AddScoped<IAuthenticateUserService, AuthenticateUserService>();

            services.AddScoped<ICreatePlayerService, CreatePlayerService>();
            services.AddScoped<IUpdatePlayerService, UpdatePlayerService>();
            services.AddScoped<IMeInfoService, MeInfoService>();

        }
    }
}

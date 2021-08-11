using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;
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

            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<ICreatePlayerService, CreatePlayerService>();
        }
    }
}

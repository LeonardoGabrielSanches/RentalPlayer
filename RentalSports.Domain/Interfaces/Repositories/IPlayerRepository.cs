using RentalSports.Domain.Entities;

namespace RentalSports.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Player GetPlayerByEmail(string email);
    }
}

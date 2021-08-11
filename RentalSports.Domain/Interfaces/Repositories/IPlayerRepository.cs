using RentalSports.Domain.Entities;

namespace RentalSports.Domain.Interfaces.Repositories
{
    public interface IPlayerRepository
    {
        Player GetPlayerByEmail(string email);
        Player Save(Player player);
    }
}

using RentalSports.Domain.Entities;

namespace RentalSports.Domain.Interfaces.Services
{
    public interface ICreatePlayerService
    {
        Player Create(Player player);
    }
}

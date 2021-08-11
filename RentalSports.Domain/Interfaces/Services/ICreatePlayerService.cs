using RentalSports.Domain.DTOs;
using RentalSports.Domain.Entities;

namespace RentalSports.Domain.Interfaces.Services
{
    public interface ICreatePlayerService
    {
        Player Create(CreatePlayerDTO createPlayerDTO);
    }
}

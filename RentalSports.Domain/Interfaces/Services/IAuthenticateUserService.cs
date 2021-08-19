using RentalSports.Domain.Entities;

namespace RentalSports.Domain.Interfaces.Services
{
    public interface IAuthenticateUserService
    {
        User AuthenticateUser(User user);
    }
}

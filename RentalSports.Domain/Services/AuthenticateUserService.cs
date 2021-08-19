using RentalSports.Domain.Entities;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.Domain.Provider;

namespace RentalSports.Domain.Services
{
    public class AuthenticateUserService : IAuthenticateUserService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly EncryptProvider _encryptProvider;

        public AuthenticateUserService(IPlayerRepository playerRepository,
                                       EncryptProvider encryptProvider)
        {
            _playerRepository = playerRepository;
            _encryptProvider = encryptProvider;
        }

        public User AuthenticateUser(User user)
        {
            var findUser = _playerRepository.GetPlayerByEmail(user.Email);

            if (findUser is null)
            {
                user.AddNotification(nameof(User), "Email de usuário não encontrado.");
                return user;
            }

            if (!_encryptProvider.PasswordMatch(password: user.Password,
                                                encryptedPassword: findUser.Password))
            {
                user.AddNotification(nameof(User), "Email ou senha incorretos.");
                return user;
            }

            return findUser;
        }
    }
}

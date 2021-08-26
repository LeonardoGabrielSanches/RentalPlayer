using RentalSports.Domain.Entities;
using RentalSports.Domain.Errors;
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
                throw new DomainException("Email de usuário não encontrado.");

            if (!_encryptProvider.PasswordMatch(password: user.Password,
                                                encryptedPassword: findUser.Password))
                throw new DomainException("Email ou senha incorretos.");

            return findUser;
        }
    }
}

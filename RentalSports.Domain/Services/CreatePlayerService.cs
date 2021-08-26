using RentalSports.Domain.Entities;
using RentalSports.Domain.Errors;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;
using RentalSports.Domain.Provider;

namespace RentalSports.Domain.Services
{
    public class CreatePlayerService : ICreatePlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly EncryptProvider _encryptProvider;

        public CreatePlayerService(IPlayerRepository playerRepository,
                                   EncryptProvider encryptProvider)
        {
            _playerRepository = playerRepository;
            _encryptProvider = encryptProvider;
        }

        public Player Create(Player player)
        {
            if (player.Invalid)
                throw new DomainException(player.NotificationError);

            var playerWithSameEmail = _playerRepository.GetPlayerByEmail(player.Email);

            if (PlayerAlreadyExists(playerWithSameEmail))
                throw new DomainException("Um usuário já foi cadastrado com este e-mail.");

            string encryptedPassword = _encryptProvider.EncryptPassword(player.Password);

            player.ApplyEncryptedPassword(encryptedPassword);

            _playerRepository.Save(player);

            return player;
        }

        private bool PlayerAlreadyExists(Player player)
            => !player.IsEmpty();
    }
}

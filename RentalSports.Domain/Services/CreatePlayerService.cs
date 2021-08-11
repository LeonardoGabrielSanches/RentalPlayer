using RentalSports.Domain.DTOs;
using RentalSports.Domain.Entities;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;

namespace RentalSports.Domain.Services
{
    public class CreatePlayerService : ICreatePlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public CreatePlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public Player Create(CreatePlayerDTO createPlayerDTO)
        {
            var player = (Player)createPlayerDTO;

            player.Validate();

            if (player.Invalid)
                return player;

            var playerWithSameEmail = _playerRepository.GetPlayerByEmail(player.Email);

            if (PlayerAlreadyExists(playerWithSameEmail))
            {
                player.AddNotification(nameof(Player), "Um usuário já foi cadastrado com este e-mail.");
                return player;
            }

            _playerRepository.Save(player);

            return player;
        }

        private bool PlayerAlreadyExists(Player player)
            => !player.IsEmpty();
    }
}

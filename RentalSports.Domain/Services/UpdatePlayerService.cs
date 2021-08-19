using RentalSports.Domain.Entities;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;

namespace RentalSports.Domain.Services
{
    public class UpdatePlayerService : IUpdatePlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly UserAuthenticated _userAuthenticated;

        public UpdatePlayerService(IPlayerRepository playerRepository,
                                   UserAuthenticated userAuthenticated)
        {
            _playerRepository = playerRepository;
            _userAuthenticated = userAuthenticated;
        }

        public Player Update(Player player)
        {
            var playerDB = _playerRepository.GetById(_userAuthenticated.Id);

            if (playerDB is null)
            {
                player.AddNotification("Usuário não encontrado.");
                return player;
            }

            var findPlayerEmail = _playerRepository.GetPlayerByEmail(player.Email);

            if (!CanUpdateEmail(findPlayerEmail))
            {
                player.AddNotification("Email já está sendo utilizado.");
                return player;
            }

            playerDB.Update(name: player.Name,
                        email: player.Email,
                        height: player.Height,
                        weight: player.Weight,
                        birth: player.Birth,
                        mobileNumber: player.MobileNumber,
                        location: new ValueObject.Location(latitude: player.Location.Latitude,
                                                           longitude: player.Location.Longitude));

            playerDB.Validate();

            if (!playerDB.IsValid)
                return player;

            _playerRepository.Update(playerDB);

            return playerDB;
        }

        private bool CanUpdateEmail(Player player)
            => player is null || player.Id == _userAuthenticated.Id;
    }
}

using RentalSports.Domain.Entities;
using RentalSports.Domain.Errors;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Domain.Interfaces.Services;

namespace RentalSports.Domain.Services
{
    public class MeInfoService : IMeInfoService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly UserAuthenticated _userAuthenticated;

        public MeInfoService(IPlayerRepository playerRepository,
                            UserAuthenticated userAuthenticated)
        {
            _playerRepository = playerRepository;
            _userAuthenticated = userAuthenticated;
        }

        public Player Get()
        {
            var me = _playerRepository.GetById(_userAuthenticated.Id);

            if (me is null)
                throw new DomainException("Usuário não encontrado.");

            return me;
        }
    }
}

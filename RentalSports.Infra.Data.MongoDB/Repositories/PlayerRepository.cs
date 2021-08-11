using MongoDB.Driver;
using RentalSports.Domain.Entities;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Infra.Data.MongoDB.Constants;
using RentalSports.Infra.Data.MongoDB.Documents;

namespace RentalSports.Infra.Data.MongoDB.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoCollection<PlayerDocument> _playerCollection;

        public PlayerRepository(DBContext dBContext)
        {
            _playerCollection = dBContext.database.GetCollection<PlayerDocument>(PlayerConstants.Database);
        }

        public Player GetPlayerByEmail(string email)
            => _playerCollection.Find(x => x.Email == email).FirstOrDefault();

        public Player Save(Player player)
        {
            var playerDocument = (PlayerDocument)player;

            _playerCollection.InsertOne(playerDocument);

            return player;
        }
    }
}

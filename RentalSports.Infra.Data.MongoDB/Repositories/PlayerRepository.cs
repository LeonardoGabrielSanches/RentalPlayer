using MongoDB.Driver;
using RentalSports.Domain.Entities;
using RentalSports.Domain.Interfaces.Repositories;
using RentalSports.Infra.Data.MongoDB.Constants;
using RentalSports.Infra.Data.MongoDB.Documents;
using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Bson;

namespace RentalSports.Infra.Data.MongoDB.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly IMongoCollection<PlayerDocument> _playerCollection;

        public PlayerRepository(DBContext dBContext)
        {
            _playerCollection = dBContext.database.GetCollection<PlayerDocument>(PlayerConstants.Database);
        }

        public IEnumerable<Player> GetAll()
            => _playerCollection.Find(_ => true).ToList().Select(player => (Player)player);

        public Player GetById(string id)
        {
            var objectId = ObjectId.Parse(id);

            return _playerCollection.Find(x => x.Id == objectId).FirstOrDefault();
        }

        public Player GetPlayerByEmail(string email)
            => _playerCollection.Find(x => x.Email == email).FirstOrDefault();

        public Player Save(Player entity)
        {
            _playerCollection.InsertOne(entity);

            return entity;
        }

        public Player Update(Player entity)
        {
            var objectId = ObjectId.Parse(entity.Id);

            _playerCollection.ReplaceOne(x => x.Id == objectId, entity);

            return entity;
        }

        public void Delete(Player entity)
        {
            _playerCollection.DeleteOne(x => x.Id.ToString() == entity.Id);
        }
    }
}

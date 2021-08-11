using MongoDB.Driver;
using System;

namespace RentalSports.Infra.Data.MongoDB
{
    public class DBContext : IDisposable
    {
        private IMongoClient _client;
        public IMongoDatabase database;

        public DBContext(string uri)
        {
            _client = new MongoClient(uri);
            if (_client != null)
                database = _client.GetDatabase("RentalSports");
        }

        public void Dispose()
        {
            _client = null;
            database = null;
        }
    }
}

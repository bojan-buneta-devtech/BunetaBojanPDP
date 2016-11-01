using System.Configuration;
using MongoDB.Driver;
using VisitingAPI.Models;

namespace VisitingAPI.Mongo
{
    public class VisitingContext
    {
        private readonly IMongoDatabase _db;

        public VisitingContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("visitApi");
        }

        public IMongoCollection<Visit> Visits => _db.GetCollection<Visit>("Visit");
    }
}
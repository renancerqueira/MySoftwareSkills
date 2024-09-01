using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MySoftwareSkills.Domain.Entities;

namespace MySoftwareSkills.Infrastructure.Data
{
    public class MongoDbContext : IMongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Skill> Skills => _database.GetCollection<Skill>("Skills");
    }
}

using MongoDB.Driver;
using MySoftwareSkills.Domain.Entities;

namespace MySoftwareSkills.Infrastructure.Data
{
    public interface IMongoDbContext
    {
        IMongoCollection<Skill> Skills { get; }
    }
}

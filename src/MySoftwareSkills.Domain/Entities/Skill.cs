using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MySoftwareSkills.Domain.Entities
{
    public class Skill
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = default!;
        
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}

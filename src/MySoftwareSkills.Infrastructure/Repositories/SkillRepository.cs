using MongoDB.Driver;
using MySoftwareSkills.Domain.Entities;
using MySoftwareSkills.Domain.Interfaces;
using MySoftwareSkills.Infrastructure.Data;

namespace MySoftwareSkills.Infrastructure.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly IMongoCollection<Skill> _skills;

        // Construtor original
        public SkillRepository(IMongoDbContext context)
        {
            _skills = context.Skills;
        }

        // Construtor adicional para testes
        public SkillRepository(IMongoCollection<Skill> skillsCollection)
        {
            _skills = skillsCollection;
        }

        public async Task<IEnumerable<Skill>> GetAllAsync()
        {
            return await _skills.Find(skill => true).ToListAsync();
        }

        public async Task<Skill> GetByIdAsync(string id)
        {
            return await _skills.Find(skill => skill.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(Skill skill)
        {
            await _skills.InsertOneAsync(skill);
        }

        public async Task UpdateAsync(Skill skill)
        {
            await _skills.ReplaceOneAsync(s => s.Id == skill.Id, skill);
        }

        public async Task DeleteAsync(Skill skill)
        {
            await _skills.DeleteOneAsync(s => s.Id == skill.Id);
        }
    }
}

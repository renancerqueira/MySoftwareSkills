using Moq;
using MongoDB.Driver;
using MySoftwareSkills.Domain.Entities;
using MySoftwareSkills.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MySoftwareSkills.Tests.Repositories
{
    public class SkillRepositoryTests
    {
        private readonly Mock<IMongoCollection<Skill>> _mockSkillCollection;
        private readonly SkillRepository _skillRepository;

        public SkillRepositoryTests()
        {
            _mockSkillCollection = new Mock<IMongoCollection<Skill>>();
            _skillRepository = new SkillRepository(_mockSkillCollection.Object);
        }

        [Fact]
        public async Task AddAsync_ShouldInsertSkill()
        {
            // Arrange
            var skill = new Skill { Name = "New Skill", Description = "New skill description" };

            // Act
            await _skillRepository.AddAsync(skill);

            // Assert
            _mockSkillCollection.Verify(x => x.InsertOneAsync(skill, null, default), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReplaceSkill()
        {
            // Arrange
            var skill = new Skill { Id = "1", Name = "Updated Skill", Description = "Updated description" };

            // Act
            await _skillRepository.UpdateAsync(skill);

            // Assert
            _mockSkillCollection.Verify(x => x.ReplaceOneAsync(It.IsAny<FilterDefinition<Skill>>(), skill, It.IsAny<ReplaceOptions>(), default), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveSkill()
        {
            // Arrange
            var skill = new Skill { Id = "1", Name = "Skill to Delete" };

            // Act
            await _skillRepository.DeleteAsync(skill);

            // Assert
            _mockSkillCollection.Verify(x => x.DeleteOneAsync(It.IsAny<FilterDefinition<Skill>>(), default), Times.Once);
        }
    }
}

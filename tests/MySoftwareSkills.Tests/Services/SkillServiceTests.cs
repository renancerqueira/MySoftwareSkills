using Moq;
using MySoftwareSkills.Application.DTOs;
using MySoftwareSkills.Application.Interfaces;
using MySoftwareSkills.Application.Services;
using MySoftwareSkills.Domain.Entities;
using MySoftwareSkills.Domain.Interfaces;

namespace MySoftwareSkills.Tests.Services
{
    public class SkillServiceTests
    {
        private readonly Mock<ISkillRepository> _mockSkillRepository;
        private readonly ISkillService _skillService;

        public SkillServiceTests()
        {
            _mockSkillRepository = new Mock<ISkillRepository>();
            _skillService = new SkillService(_mockSkillRepository.Object);
        }

        [Fact]
        public async Task GetAllSkillsAsync_ShouldReturnAllSkills()
        {
            // Arrange
            var skills = new List<Skill>
            {
                new Skill { Id = "1", Name = "Software Development", Description = "Development description" },
                new Skill { Id = "2", Name = "Cloud Computing", Description = "Cloud description" }
            };

            _mockSkillRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(skills);

            // Act
            var result = await _skillService.GetAllSkillsAsync();

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Software Development", result.First().Name);
        }

        [Fact]
        public async Task GetSkillByIdAsync_ShouldReturnSkill_WhenSkillExists()
        {
            // Arrange
            var skill = new Skill { Id = "1", Name = "Software Development", Description = "Development description" };
            _mockSkillRepository.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(skill);

            // Act
            var result = await _skillService.GetSkillByIdAsync("1");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Software Development", result.Name);
        }

        [Fact]
        public async Task GetSkillByIdAsync_ShouldReturnNull_WhenSkillDoesNotExist()
        {
            // Arrange
            _mockSkillRepository.Setup(repo => repo.GetByIdAsync("99")).ReturnsAsync((Skill)null);

            // Act
            var result = await _skillService.GetSkillByIdAsync("99");

            // Assert
            Assert.Null(result.Id);
        }

        [Fact]
        public async Task CreateSkillAsync_ShouldReturnCreatedSkill()
        {
            // Arrange
            var skillDto = new SkillDto { Name = "New Skill", Description = "New skill description" };
            var skill = new Skill { Id = "1", Name = "New Skill", Description = "New skill description" };

            _mockSkillRepository.Setup(repo => repo.AddAsync(It.IsAny<Skill>())).Callback<Skill>(s => s.Id = "1");

            // Act
            var result = await _skillService.CreateSkillAsync(skillDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("1", result.Id);
            Assert.Equal("New Skill", result.Name);
        }

        [Fact]
        public async Task UpdateSkillAsync_ShouldReturnUpdatedSkill_WhenSkillExists()
        {
            // Arrange
            var existingSkill = new Skill { Id = "1", Name = "Existing Skill", Description = "Old description" };
            var updatedSkillDto = new SkillDto { Name = "Updated Skill", Description = "Updated description" };

            _mockSkillRepository.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(existingSkill);

            // Act
            var result = await _skillService.UpdateSkillAsync("1", updatedSkillDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Updated Skill", result.Name);
            Assert.Equal("Updated description", result.Description);
        }

        [Fact]
        public async Task UpdateSkillAsync_ShouldReturnNull_WhenSkillDoesNotExist()
        {
            // Arrange
            var updatedSkillDto = new SkillDto { Name = "Updated Skill", Description = "Updated description" };

            _mockSkillRepository.Setup(repo => repo.GetByIdAsync("99")).ReturnsAsync((Skill)null);

            // Act
            var result = await _skillService.UpdateSkillAsync("99", updatedSkillDto);

            // Assert
            Assert.Null(result.Id);
        }

        [Fact]
        public async Task DeleteSkillAsync_ShouldReturnTrue_WhenSkillIsDeleted()
        {
            // Arrange
            var skill = new Skill { Id = "1", Name = "Skill to Delete" };
            _mockSkillRepository.Setup(repo => repo.GetByIdAsync("1")).ReturnsAsync(skill);
            _mockSkillRepository.Setup(repo => repo.DeleteAsync(skill)).Returns(Task.CompletedTask);

            // Act
            var result = await _skillService.DeleteSkillAsync("1");

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteSkillAsync_ShouldReturnFalse_WhenSkillDoesNotExist()
        {
            // Arrange
            _mockSkillRepository.Setup(repo => repo.GetByIdAsync("99")).ReturnsAsync((Skill)null);

            // Act
            var result = await _skillService.DeleteSkillAsync("99");

            // Assert
            Assert.False(result);
        }
    }
}

using Moq;
using MySoftwareSkills.Application.DTOs;
using MySoftwareSkills.Application.Interfaces;
using MySoftwareSkills.Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MySoftwareSkills.Tests.Controllers
{
    public class SkillsControllerTests
    {
        private readonly Mock<ISkillService> _mockSkillService;
        private readonly SkillsController _skillsController;

        public SkillsControllerTests()
        {
            _mockSkillService = new Mock<ISkillService>();
            _skillsController = new SkillsController(_mockSkillService.Object);
        }

        [Fact]
        public async Task GetSkills_ShouldReturnOkResult_WithListOfSkills()
        {
            // Arrange
            var skills = new List<SkillDto>
            {
                new SkillDto { Id = "1", Name = "Software Development", Description = "Development description" },
                new SkillDto { Id = "2", Name = "Cloud Computing", Description = "Cloud description" }
            };

            _mockSkillService.Setup(service => service.GetAllSkillsAsync()).ReturnsAsync(skills);

            // Act
            var result = await _skillsController.GetAllSkills();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<SkillDto>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public async Task GetSkillById_ShouldReturnOkResult_WithSkill()
        {
            // Arrange
            var skill = new SkillDto { Id = "1", Name = "Software Development", Description = "Development description" };

            _mockSkillService.Setup(service => service.GetSkillByIdAsync("1")).ReturnsAsync(skill);

            // Act
            var result = await _skillsController.GetSkillById("1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<SkillDto>(okResult.Value);
            Assert.Equal("Software Development", returnValue.Name);
        }

        [Fact]
        public async Task GetSkillById_ShouldReturnNotFound_WhenSkillDoesNotExist()
        {
            // Arrange
            _mockSkillService.Setup(service => service.GetSkillByIdAsync("99")).ReturnsAsync((SkillDto)null);

            // Act
            var result = await _skillsController.GetSkillById("99");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateSkill_ShouldReturnCreatedAtActionResult_WithSkill()
        {
            // Arrange
            var skillDto = new SkillDto { Name = "New Skill", Description = "New skill description" };

            _mockSkillService.Setup(service => service.CreateSkillAsync(skillDto))
                             .ReturnsAsync(new SkillDto { Id = "1", Name = "New Skill", Description = "New skill description" });

            // Act
            var result = await _skillsController.CreateSkill(skillDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnValue = Assert.IsType<SkillDto>(createdAtActionResult.Value);
            Assert.Equal("New Skill", returnValue.Name);
            Assert.Equal("1", returnValue.Id);
        }

        [Fact]
        public async Task UpdateSkill_ShouldReturnNoContentResult_WhenSkillIsUpdated()
        {
            // Arrange
            var skillDto = new SkillDto { Name = "Updated Skill", Description = "Updated description" };

            _mockSkillService.Setup(service => service.UpdateSkillAsync("1", skillDto)).ReturnsAsync(skillDto);

            // Act
            var result = await _skillsController.UpdateSkill("1", skillDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task UpdateSkill_ShouldReturnNotFound_WhenSkillDoesNotExist()
        {
            // Arrange
            var skillDto = new SkillDto { Name = "Updated Skill", Description = "Updated description" };

            _mockSkillService.Setup(service => service.UpdateSkillAsync("99", skillDto)).ReturnsAsync((SkillDto)null);

            // Act
            var result = await _skillsController.UpdateSkill("99", skillDto);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteSkill_ShouldReturnNoContentResult_WhenSkillIsDeleted()
        {
            // Arrange
            _mockSkillService.Setup(service => service.DeleteSkillAsync("1")).ReturnsAsync(true);

            // Act
            var result = await _skillsController.DeleteSkill("1");

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteSkill_ShouldReturnNotFound_WhenSkillDoesNotExist()
        {
            // Arrange
            _mockSkillService.Setup(service => service.DeleteSkillAsync("99")).ReturnsAsync(false);

            // Act
            var result = await _skillsController.DeleteSkill("99");

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

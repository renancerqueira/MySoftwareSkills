using Microsoft.AspNetCore.Mvc;
using MySoftwareSkills.Application.Interfaces;
using MySoftwareSkills.Application.DTOs;

namespace MySoftwareSkills.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;

        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            var skills = await _skillService.GetAllSkillsAsync();
            return Ok(skills);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkillById(string id)
        {
            var skill = await _skillService.GetSkillByIdAsync(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] SkillDto skillDto)
        {
            var createdSkill = await _skillService.CreateSkillAsync(skillDto);
            return CreatedAtAction(nameof(GetSkillById), new { id = createdSkill.Id }, createdSkill);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSkill(string id, [FromBody] SkillDto skillDto)
        {
            var updatedSkill = await _skillService.UpdateSkillAsync(id, skillDto);
            if (updatedSkill == null)
            {
                return NotFound();
            }
            return Ok(updatedSkill);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(string id)
        {
            var deleted = await _skillService.DeleteSkillAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

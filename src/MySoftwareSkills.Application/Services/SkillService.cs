using MySoftwareSkills.Application.DTOs;
using MySoftwareSkills.Application.Interfaces;
using MySoftwareSkills.Domain.Entities;
using MySoftwareSkills.Domain.Interfaces;

namespace MySoftwareSkills.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;

        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkillsAsync()
        {
            var skills = await _skillRepository.GetAllAsync();
            return skills.Select(s => new SkillDto
            {
                Id = s.Id.ToString(),
                Name = s.Name,
                Description = s.Description
            });
        }

        public async Task<SkillDto> GetSkillByIdAsync(string id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                return new SkillDto();
            }
            return new SkillDto
            {
                Id = skill.Id.ToString(),
                Name = skill.Name,
                Description = skill.Description
            };
        }

        public async Task<SkillDto> CreateSkillAsync(SkillDto skillDto)
        {
            var skill = new Skill
            {
                Name = skillDto.Name,
                Description = skillDto.Description
            };
            await _skillRepository.AddAsync(skill);
            return new SkillDto
            {
                Id = skill.Id.ToString(),
                Name = skill.Name,
                Description = skill.Description
            };
        }

        public async Task<SkillDto> UpdateSkillAsync(string id, SkillDto skillDto)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                return new SkillDto();
            }
            skill.Name = skillDto.Name;
            skill.Description = skillDto.Description;
            await _skillRepository.UpdateAsync(skill);
            return skillDto;
        }

        public async Task<bool> DeleteSkillAsync(string id)
        {
            var skill = await _skillRepository.GetByIdAsync(id);
            if (skill == null)
            {
                return false;
            }
            await _skillRepository.DeleteAsync(skill);
            return true;
        }
    }
}

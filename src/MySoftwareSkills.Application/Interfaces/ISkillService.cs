using MySoftwareSkills.Application.DTOs;

namespace MySoftwareSkills.Application.Interfaces
{
    public interface ISkillService
    {
        Task<IEnumerable<SkillDto>> GetAllSkillsAsync();
        Task<SkillDto> GetSkillByIdAsync(string id);
        Task<SkillDto> CreateSkillAsync(SkillDto skillDto);
        Task<SkillDto> UpdateSkillAsync(string id, SkillDto skillDto);
        Task<bool> DeleteSkillAsync(string id);
    }
}

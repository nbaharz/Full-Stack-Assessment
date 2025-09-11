using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IGradeService: IGenericService<Grade>
    {
        Task<IEnumerable<Grade>> GetByStudentIdAsync(Guid studentId);
        Task AddGradeAsync(GradeCreateDto dto);
    }
}

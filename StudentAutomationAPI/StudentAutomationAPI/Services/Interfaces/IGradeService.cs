using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IGradeService: IGenericService<Grade>
    {
        Task<IEnumerable<Grade>> GetByStudentIdAsync(Guid studentId);
        Task AddGradeAsync(Guid studentId, Guid courseId, double value);
    }
}

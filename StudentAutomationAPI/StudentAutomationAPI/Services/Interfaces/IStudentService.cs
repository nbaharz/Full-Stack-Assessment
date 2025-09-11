using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IStudentService: IGenericService<Student>
    {
        Task<Student?> GetOwnProfileAsync(Guid studentId);
        Task<Student?> GetByUserIdAsync(Guid userId);
        Task<Student> CreateStudentAsync(StudentCreateDto dto);
    }
}

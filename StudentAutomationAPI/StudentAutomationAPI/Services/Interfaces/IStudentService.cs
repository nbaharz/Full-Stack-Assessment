using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface IStudentService: IGenericService<Student>
    {
        Task<Student?> GetOwnProfileAsync(Guid studentId);
    }
}

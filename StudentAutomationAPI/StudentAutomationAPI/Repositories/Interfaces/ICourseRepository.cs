using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public interface ICourseRepository: IGenericRepository<Course>
    {
        Task UpdateCourseStatusAsync(Guid courseId, string status);
    }
}

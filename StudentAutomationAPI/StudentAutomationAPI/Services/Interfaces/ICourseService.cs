using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface ICourseService: IGenericService<Course>
    {
        Task AddCourseAsync(CourseCreateDto dto);
        Task UpdateCourseStatusAsync(Guid courseId, string status);
    }
}

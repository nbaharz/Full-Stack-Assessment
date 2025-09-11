using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface ITeacherService: IGenericService<Teacher>
    {
        Task<IEnumerable<Course>> GetCoursesAsync(Guid teacherId);
    }
}

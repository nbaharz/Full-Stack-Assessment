using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface ITeacherService: IGenericService<Teacher>
    {
        public Task<IEnumerable<Course>> GetCoursesAsync(Guid teacherId);
        Task<Teacher> CreateTeacherAsync(TeacherDto dto);

    }
}

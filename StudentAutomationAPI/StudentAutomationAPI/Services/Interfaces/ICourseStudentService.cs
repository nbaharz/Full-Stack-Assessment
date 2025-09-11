using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface ICourseStudentService: IGenericService<CourseStudent>
    {
        Task AddStudentToCourseAsync(Guid courseId, Guid studentId);
        Task RemoveStudentFromCourseAsync(Guid courseId, Guid studentId);
        Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseId);
    }
}

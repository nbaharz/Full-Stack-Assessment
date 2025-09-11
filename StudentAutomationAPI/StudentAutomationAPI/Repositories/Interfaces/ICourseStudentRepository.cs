using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public interface ICourseStudentRepository: IGenericRepository<CourseStudent>
    {
        Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseId);
        Task<CourseStudent?> GetCourseStudentAsync(Guid courseId, Guid studentId);
    }
}

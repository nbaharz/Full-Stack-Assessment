using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public interface IStudentRepository:IGenericRepository<Student>
    {
        Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseId);
    }
}

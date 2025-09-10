using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AutomationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseId)
        {
            throw new NotImplementedException();
        }
    }
}

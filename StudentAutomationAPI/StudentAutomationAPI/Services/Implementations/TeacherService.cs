using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;

namespace StudentAutomationAPI.Services.Implementations
{
    public class TeacherService : GenericService<Teacher>, ITeacherService
    {
        public TeacherService(IGenericRepository<Teacher> repository) : base(repository)
        {
        }

        public Task<IEnumerable<Course>> GetCoursesAsync(Guid teacherId)
        {
            throw new NotImplementedException();
        }
    }
}

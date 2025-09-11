using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;

namespace StudentAutomationAPI.Services.Implementations
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        public StudentService(IGenericRepository<Student> repository) : base(repository)
        {
        }

        public Task<Student?> GetOwnProfileAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }
    }
}

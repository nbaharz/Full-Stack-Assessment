using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;

namespace StudentAutomationAPI.Services.Implementations
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentService(IGenericRepository<Student> repository) : base(repository)
        {
            _studentRepository = repository;
        }

        public async Task<Student?> GetOwnProfileAsync(Guid studentId)
        {
            var students = await _studentRepository.FindAsync(s => s.Id == studentId);
            return students.FirstOrDefault();
        }
    }
}

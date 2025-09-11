using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;
using StudentAutomationAPI.Services.Interfaces;

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

        public async Task<Student?> GetByUserIdAsync(Guid userId)
        {
            var students = await _studentRepository.FindAsync(s => s.UserId == userId);
            return students.FirstOrDefault();
        }

        public async Task<Student> CreateStudentAsync(StudentCreateDto dto)
        {
            var student = new Student
            {
                UserId = dto.UserId,
                FullName = dto.FullName,
                StudentNumber = dto.StudentNumber
            };

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return student;
        }


    }
}

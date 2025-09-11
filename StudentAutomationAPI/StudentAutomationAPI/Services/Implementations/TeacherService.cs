using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;

namespace StudentAutomationAPI.Services.Implementations
{
    public class TeacherService : GenericService<Teacher>, ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        private readonly ICourseRepository _courseRepository;
        public TeacherService(ITeacherRepository repository, ICourseRepository courseRepository) : base(repository)
        {
            teacherRepository = repository;
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetCoursesAsync(Guid teacherId)
        {
            return await _courseRepository.FindAsync(c => c.TeacherId == teacherId);
        }
    }
}

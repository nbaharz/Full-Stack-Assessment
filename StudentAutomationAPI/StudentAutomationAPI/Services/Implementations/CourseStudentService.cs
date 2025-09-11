using StudentAutomationAPI.Services.Interfaces;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;
using System.Linq.Expressions;

namespace StudentAutomationAPI.Services.Implementations
{
    public class CourseStudentService : GenericService<CourseStudent>, ICourseStudentService
    {

        private readonly ICourseStudentRepository _courseStudentRepository;

        public CourseStudentService(ICourseStudentRepository repository) : base(repository)
        {
            _courseStudentRepository = repository;
        }

        public async Task AddStudentToCourseAsync(Guid courseId, Guid studentId)
        {
            var courseStudent = new CourseStudent
            {
                CourseId = courseId,
                StudentId = studentId
            };

            await _courseStudentRepository.AddAsync(courseStudent);
        }

        public async Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseId)
        {
            return await _courseStudentRepository.GetStudentsByCourseAsync(courseId);
        }

        public async Task RemoveStudentFromCourseAsync(Guid courseId, Guid studentId)
        {
            var courseStudent = await _courseStudentRepository.GetCourseStudentAsync(courseId, studentId);
            if (courseStudent != null)
            {
                _courseStudentRepository.Delete(courseStudent);
            }
        }
    }
}

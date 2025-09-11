using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Services.Implementations
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository repository) : base(repository)
        {
            courseRepository = repository;
        }
        public async Task AddCourseAsync(CourseCreateDto dto)
        {
            var course = new Course
            {
                Name = dto.Name,
                Description = dto.Description,
                TeacherId = dto.TeacherId,
            };

            await courseRepository.AddAsync(course);
       
        }

        public async Task UpdateCourseStatusAsync(Guid courseId, string status)
        {
            await courseRepository.UpdateCourseStatusAsync(courseId,status);
        }

        
    }
}

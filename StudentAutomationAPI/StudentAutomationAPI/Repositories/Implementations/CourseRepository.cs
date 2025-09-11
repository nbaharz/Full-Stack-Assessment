using Microsoft.EntityFrameworkCore;
using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly AutomationDbContext _context;

        public CourseRepository(AutomationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateCourseStatusAsync(Guid courseId, string status)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
                throw new Exception("Course not found");

            course.Status = status;
            _context.Courses.Update(course);
        }
    }
}

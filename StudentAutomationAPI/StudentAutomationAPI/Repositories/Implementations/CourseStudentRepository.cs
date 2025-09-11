using Microsoft.EntityFrameworkCore;
using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class CourseStudentRepository : GenericRepository<CourseStudent>, ICourseStudentRepository
    {
        private readonly AutomationDbContext _context;

        public CourseStudentRepository(AutomationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetStudentsByCourseAsync(Guid courseId)
        {
            return await _context.CourseStudents
                .Where(cs => cs.CourseId == courseId)
                .Include(cs => cs.Student)
                .Select(cs => cs.Student)
                .ToListAsync();
        }

        public async Task<CourseStudent?> GetCourseStudentAsync(Guid courseId, Guid studentId)
        {
            return await _context.CourseStudents
                .FirstOrDefaultAsync(cs => cs.CourseId == courseId && cs.StudentId == studentId);
        }
    }
}

using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class CourseStudentRepository : GenericRepository<CourseStudent>, ICourseStudentRepository
    {
        public CourseStudentRepository(AutomationDbContext context) : base(context)
        {
        }
    }
}

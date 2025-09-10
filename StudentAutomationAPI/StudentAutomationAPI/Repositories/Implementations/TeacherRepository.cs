using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(AutomationDbContext context) : base(context)
        {
        }
    }
}

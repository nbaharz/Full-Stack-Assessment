using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly AutomationDbContext _context;
        public StudentRepository(AutomationDbContext context) : base(context)
        {
            _context = context;
        }

        
    }
}

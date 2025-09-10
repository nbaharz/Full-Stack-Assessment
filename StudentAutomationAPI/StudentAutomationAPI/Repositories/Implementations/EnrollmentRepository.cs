using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(AutomationDbContext context) : base(context)
        {
        }
    }
}

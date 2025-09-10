using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AutomationDbContext context) : base(context)
        {
        }
    }
}

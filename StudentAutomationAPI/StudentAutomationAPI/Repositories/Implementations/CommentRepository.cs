using StudentAutomationAPI.Data;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Repositories.Implementations
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AutomationDbContext context) : base(context)
        {
        }
    }
}

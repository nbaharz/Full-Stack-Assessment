using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;

namespace StudentAutomationAPI.Services.Interfaces
{
    public interface ICommentService:IGenericService<Comment>
    {
        Task<IEnumerable<Comment>> GetByStudentIdAsync(Guid studentId);
        Task<Comment> AddCommentAsync(CommentCreateDto);
    }
}

using StudentAutomationAPI.DTO;
using StudentAutomationAPI.Entities;
using StudentAutomationAPI.Repositories.Implementations;
using StudentAutomationAPI.Services.Interfaces;

namespace StudentAutomationAPI.Services.Implementations
{
    public class CommentService: GenericService<Comment>, ICommentService
    {
        private readonly ICommentRepository commentRepository;
        public CommentService(ICommentRepository repository) : base(repository)
        {
            commentRepository = repository;
        }

        public async Task<Comment> AddCommentAsync(CommentCreateDto dto)
        {
            var comment = new Comment
            {
                CourseId = dto.CourseId,
                StudentId = dto.StudentId,
                TeacherId = dto.TeacherId,
                Text = dto.Text,
            };

            await commentRepository.AddAsync(comment);
            return comment;
        }

       

        public async Task<IEnumerable<Comment>> GetByStudentIdAsync(Guid studentId)
        {
            return await commentRepository.FindAsync(c => c.StudentId == studentId);
        }
    }
}

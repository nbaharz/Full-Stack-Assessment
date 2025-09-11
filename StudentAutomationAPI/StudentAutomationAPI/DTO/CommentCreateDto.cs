namespace StudentAutomationAPI.DTO
{
    public class CommentCreateDto
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public string Text { get; set; } = null!;
    }
}

namespace StudentAutomationAPI.Entities
{
    public class Comment: BaseEntity
    {
        public Guid CommentId { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public Guid TeacherId { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
    }
}

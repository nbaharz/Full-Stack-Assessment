namespace StudentAutomationAPI.Entities
{
    public class Enrollment:BaseEntity
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }

        // Navigation props
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
    }
}

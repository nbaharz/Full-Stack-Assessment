namespace StudentAutomationAPI.Entities
{
    public class CourseStudent:BaseEntity //to deal with n-n relation
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }

        // Navigation
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}

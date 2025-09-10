namespace StudentAutomationAPI.Entities
{
    public class Grade: BaseEntity
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public decimal GradeValue { get; set; }


        // Navigation
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}

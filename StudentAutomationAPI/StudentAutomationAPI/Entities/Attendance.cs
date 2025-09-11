namespace StudentAutomationAPI.Entities
{
    public class Attendance: BaseEntity
    {
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
        public DateTime Date {  get; set; }
        public string Status { get; set; } = null!; 

        // Navigation
        public Course Course { get; set; } = null!;
        public Student Student { get; set; } = null!;
    }
}
